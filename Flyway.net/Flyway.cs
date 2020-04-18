using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Flyway.net
{
    public class Flyway
    {
        private readonly string _flywayPath;

        public Flyway(string flywayPath)
        {
            if(String.IsNullOrWhiteSpace(flywayPath) || !System.IO.Directory.Exists(flywayPath))
            {
                throw new Exception("Invalid Path");
            }

            this._flywayPath = flywayPath;
        }

        /// <summary>
        /// Migrates the schema to the latest version. Flyway will create the schema history table automatically if it doesn’t exist.
        /// </summary>
        public string Migrate(FlywayMigrateOptionGroup options = null)
        {
            return Exec("migrate", options);
        }
        public Task<string> MigrateAsync(FlywayMigrateOptionGroup options = null)
        {
            return ExecAsync("migrate", options);
        }
        /// <summary>
        /// Drops all objects in the configured schemas.
        /// </summary>
        public string Clean(FlywayCleanOptionGroup options = null)
        {
            return Exec("clean", options);
        }
        public Task<string> CleanAsync(FlywayCleanOptionGroup options = null)
        {
            return ExecAsync("clean", options);
        }
        /// <summary>
        /// Prints the details and status information about all the migrations.
        /// </summary>
        public string Info(FlywayInfoOptionGroup options = null)
        {
            return Exec("info", options);
        }
        public Task<string> InfoAsync(FlywayInfoOptionGroup options = null)
        {
            return ExecAsync("info", options);
        }
        /// <summary>
        /// Validates the applied migrations against the available ones.
        /// </summary>
        public string Validate(FlywayValidateOptionGroup options = null)
        {
            return Exec("validate", options);
        }
        public Task<string> ValidateAsync(FlywayValidateOptionGroup options = null)
        {
            return ExecAsync("validate", options);
        }
        /// <summary>
        /// Undoes the most recently applied versioned migration.
        /// </summary>
        public string Undo(FlywayUndoOptionGroup options = null)
        {
            return Exec("undo", options);
        }
        public Task<string> UndoAsync(FlywayUndoOptionGroup options = null)
        {
            return ExecAsync("undo", options);
        }
        /// <summary>
        /// Baselines an existing database, excluding all migrations upto and including baselineVersion.
        /// </summary>
        public string Baseline(FlywayBaselineOptionGroup options = null)
        {
            return Exec("baseline", options);
        }
        public Task<string> BaselineAsync(FlywayBaselineOptionGroup options = null)
        {
            return ExecAsync("baseline", options);
        }
        /// <summary>
        /// Repairs the schema history table.
        /// </summary>
        public string Repair(FlywayRepairOptionGroup options = null)
        {
            return Exec("repair", options);
        }
        public Task<string> RepairAsync(FlywayRepairOptionGroup options = null)
        {
            return ExecAsync("repair", options);
        }

        private string Exec(string command, FlywayOptionGroup options)
        {
            if(String.IsNullOrWhiteSpace(command))
            {
                throw new Exception("Command is invalid!");
            }

            if(options != null && !options.Validate())
            {
                throw new Exception("Command options are invalid!");    
            }

            var output = new StringBuilder();
            var process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.WorkingDirectory = this._flywayPath;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c flyway {(options != null ? options.ToArgs() : "")} {command} ";

            process.OutputDataReceived += (sender, data) => { output.AppendLine(data.Data); };
            process.ErrorDataReceived += (sender, data) => { output.AppendLine(data.Data); };

            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Dispose();

            return output.ToString();
        }
        private Task<string> ExecAsync(string command, FlywayOptionGroup options)
        {
            return Task.Run(() => Exec(command, options));
        }
    }
}
