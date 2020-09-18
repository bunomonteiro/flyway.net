using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Flyway.net.OptionGroups;

namespace Flyway.net
{
    public class Flyway
    {
        private readonly string _flywayPath;
        public FlywayConfiguration Configuration { get; set; }

        public Flyway(string flywayPath)
        {
            if(string.IsNullOrWhiteSpace(flywayPath) || !System.IO.Directory.Exists(flywayPath))
            {
                throw new Exception("Invalid Flyway path");
            }

            _flywayPath = flywayPath;
        }

        public Flyway(FlywayConfiguration configuration)
        {
            if(configuration == null || string.IsNullOrWhiteSpace(configuration.FlywayPath) || !System.IO.Directory.Exists(configuration.FlywayPath))
            {
                throw new Exception("Invalid Flyway path");
            }

            _flywayPath = configuration.FlywayPath;
            Configuration = configuration;
        }

        /// <summary>
        /// Migrates the schema to the latest version. Flyway will create the schema history table automatically if it doesn’t exist.
        /// </summary>
        public FlywayOutputResult Migrate(FlywayMigrateOptionGroup options = null)
        {
            return Exec("migrate", options ?? Configuration);
        }
        public Task<FlywayOutputResult> MigrateAsync(FlywayMigrateOptionGroup options = null)
        {
            return ExecAsync("migrate", options ?? Configuration);
        }
        /// <summary>
        /// Drops all objects in the configured schemas.
        /// </summary>
        public FlywayOutputResult Clean(FlywayCleanOptionGroup options = null)
        {
            return Exec("clean", options ?? Configuration);
        }
        public Task<FlywayOutputResult> CleanAsync(FlywayCleanOptionGroup options = null)
        {
            return ExecAsync("clean", options ?? Configuration);
        }
        /// <summary>
        /// Prints the details and status information about all the migrations.
        /// </summary>
        public FlywayOutputResult Info(FlywayInfoOptionGroup options = null)
        {
            return Exec("info", options ?? Configuration);
        }
        public Task<FlywayOutputResult> InfoAsync(FlywayInfoOptionGroup options = null)
        {
            return ExecAsync("info", options ?? Configuration);
        }
        /// <summary>
        /// Validates the applied migrations against the available ones.
        /// </summary>
        public FlywayOutputResult Validate(FlywayValidateOptionGroup options = null)
        {
            return Exec("validate", options ?? Configuration);
        }
        public Task<FlywayOutputResult> ValidateAsync(FlywayValidateOptionGroup options = null)
        {
            return ExecAsync("validate", options ?? Configuration);
        }
        /// <summary>
        /// Undoes the most recently applied versioned migration.
        /// </summary>
        public FlywayOutputResult Undo(FlywayUndoOptionGroup options = null)
        {
            return Exec("undo", options ?? Configuration);
        }
        public Task<FlywayOutputResult> UndoAsync(FlywayUndoOptionGroup options = null)
        {
            return ExecAsync("undo", options ?? Configuration);
        }
        /// <summary>
        /// Baselines an existing database, excluding all migrations upto and including baselineVersion.
        /// </summary>
        public FlywayOutputResult Baseline(FlywayBaselineOptionGroup options = null)
        {
            return Exec("baseline", options ?? Configuration);
        }
        public Task<FlywayOutputResult> BaselineAsync(FlywayBaselineOptionGroup options = null)
        {
            return ExecAsync("baseline", options ?? Configuration);
        }
        /// <summary>
        /// Repairs the schema history table.
        /// </summary>
        public FlywayOutputResult Repair(FlywayRepairOptionGroup options = null)
        {
            return Exec("repair", options ?? Configuration);
        }
        public Task<FlywayOutputResult> RepairAsync(FlywayRepairOptionGroup options = null)
        {
            return ExecAsync("repair", options ?? Configuration);
        }

        private FlywayOutputResult Exec(string command, FlywayOptionGroup options)
        {
            if(string.IsNullOrWhiteSpace(command))
            {
                throw new Exception("Command is invalid!");
            }

            if(options != null && !options.Validate())
            {
                throw new Exception("Command options are invalid!");
            }

            FlywayOutputReader outputReader = new FlywayOutputReader();
            Process process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.WorkingDirectory = _flywayPath;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c flyway {(options != null ? options.ToArgs() : "")} {command} ";

            process.OutputDataReceived += outputReader.OnOutputDataReceived;
            process.ErrorDataReceived += outputReader.OnErrorDataReceived;

            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Dispose();

            return outputReader.ToOutputResult();
        }
        private Task<FlywayOutputResult> ExecAsync(string command, FlywayOptionGroup options)
        {
            return Task.Run(() => Exec(command, options));
        }
    }
}
