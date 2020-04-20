using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Flyway.net.ValueObjects;

namespace Flyway.net
{
    internal class FlywayOutputReader
    {
        private readonly StringBuilder _rawOutput = new StringBuilder();
        private readonly StringBuilder _data = new StringBuilder();
        private readonly StringBuilder _error = new StringBuilder();

        private bool _hasError;

        public void OutputDataReceived(string data)
        {
            if(string.IsNullOrWhiteSpace(data))
            {
                return;
            }

            if(!_hasError && data.StartsWith("ERROR:"))
            {
                _error.AppendLine(data.Substring("ERROR:".Length + 1).Trim());
            }

            _data.AppendLine(data);
            _rawOutput.AppendLine(data);
        }

        public void ErrorDataReceived(string data)
        {
            _hasError = true;

            if(string.IsNullOrWhiteSpace(data))
            {
                return;
            }

            _error.AppendLine(data);
            _rawOutput.AppendLine(data);
        }

        public void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived(e.Data);
        }
        public void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(e.Data))
            {
                ErrorDataReceived(e.Data);
            }
        }

        public FlywayOutputResult ToOutputResult()
        {
            string editionLine = GetEditionLine();
            List<string> tableLines = GetHistoryLines();

            return new FlywayOutputResult
            {
                HasError = _hasError,
                ErrorMessage = _error.ToString().Replace("ERROR:", "").Trim(),
                RawOutput = _rawOutput.ToString(),
                Edition = ParseEdition(editionLine),
                Version = ParseVersion(editionLine),
                History = ParseHistoryTable(tableLines)
            };
        }

        private List<FlywayHistory> ParseHistoryTable(List<string> tableLines)
        {
            List<FlywayHistory> history = new List<FlywayHistory>();

            if(tableLines is null || !tableLines.Any())
            {
                return history;
            }

            string[] cols;
            foreach(string row in tableLines)
            {
                cols = row.Trim().Split('|');

                if(cols.Length > 1)
                {
                    history.Add(new FlywayHistory
                    {
                        Category = cols[1].Trim(),
                        Version = cols[2].Trim(),
                        Description = cols[3].Trim(),
                        Type = cols[4].Trim(),
                        InstalledOn = string.IsNullOrWhiteSpace(cols[5]) ? null : (DateTime?)DateTime.ParseExact(cols[5].Trim(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                        State = cols[6].Trim(),
                    });
                }
            }

            return history;
        }

        private string GetEditionLine()
        {
            string[] delim = { Environment.NewLine, "\n" };
            string[] lines = _data.ToString().Split(delim, StringSplitOptions.None);

            string theLine = null;
            foreach(string line in lines)
            {
                if(line.StartsWith("Flyway") && line.Contains("Edition"))
                {
                    theLine = line;
                    break;
                }
            }

            return theLine ?? string.Empty;
        }

        private List<string> GetHistoryLines()
        {
            string[] delim = { Environment.NewLine, "\n" };
            string[] lines = _data.ToString().Split(delim, StringSplitOptions.None);
            List<string> tableLines = new List<string>();

            for(int i = 0; i < lines.Length; i++)
            {
                if(!tableLines.Any() && lines[i].StartsWith("+--"))
                {
                    i += 3;
                    tableLines.Add(lines[i]);
                    continue;
                } else if(tableLines.Any())
                {
                    if(lines[i].StartsWith("+--"))
                    {
                        break;
                    }

                    tableLines.Add(lines[i]);
                }
            }

            return tableLines;
        }

        private string ParseEdition(string line)
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                return string.Empty;
            }

            int editionIndex = line.IndexOf("Edition") - 8;
            return line.Substring(7, editionIndex);
        }

        private SemVer ParseVersion(string line)
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                return new SemVer();
            }

            return Regex.Match(line, @"\d+.+\d").Value;
        }
    }
}
