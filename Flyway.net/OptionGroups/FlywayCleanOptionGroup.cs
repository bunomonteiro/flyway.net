using System.Collections.Generic;

namespace Flyway.net.OptionGroups
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/clean
    /// </summary>
    public class FlywayCleanOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayDefaultSchemaOption DefaultSchema { get; set; }
        public FlywayColorOption Color { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayCleanDisabledOption CleanDisabled { get; set; }
        public FlywayValidateMigrationNamingOption ValidateMigrationNaming { get; set; }
        public FlywayWorkingDirectoryOption WorkingDirectory { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayCleanOptionGroup()
        {
            Url = new FlywayUrlOption();
            Driver = new FlywayDriverOption();
            User = new FlywayUserOption();
            Password = new FlywayPasswordOption();
            ConnectRetries = new FlywayConnectRetriesOption();
            InitSql = new FlywayInitSqlOption();
            Schemas = new FlywaySchemasOption();
            Color = new FlywayColorOption();
            DefaultSchema = new FlywayDefaultSchemaOption();
            JarDirs = new FlywayJarDirsOption();
            Callbacks = new FlywayCallbacksOption();
            SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            CleanDisabled = new FlywayCleanDisabledOption();
            ValidateMigrationNaming = new FlywayValidateMigrationNamingOption();
            WorkingDirectory = new FlywayWorkingDirectoryOption();
            LicenseKey = new FlywayLicenseKeyOption();
        }

        public override string ToArgs()
        {
            List<string> options = new List<string>
            {
                Url.Formatted(),
                Driver.Formatted(),
                User.Formatted(),
                Password.Formatted(),
                ConnectRetries.Formatted(),
                InitSql.Formatted(),
                Schemas.Formatted(),
                Color.Formatted(),
                DefaultSchema.Formatted(),
                JarDirs.Formatted(),
                Callbacks.Formatted(),
                SkipDefaultCallbacks.Formatted(),
                CleanDisabled.Formatted(),
                ValidateMigrationNaming.Formatted(),
                WorkingDirectory.Formatted(),
                LicenseKey.Formatted()
            };

            return ToArgs(options);
        }

        public static implicit operator FlywayCleanOptionGroup(FlywayConfiguration configuration)
        {
            FlywayCleanOptionGroup options = new FlywayCleanOptionGroup();
            options.Url.Value = configuration.Url.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.User.Value = configuration.User.Value;
            options.Password.Value = configuration.Password.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.Color.Value = configuration.Color.Value;
            options.DefaultSchema.Value = configuration.DefaultSchema.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.CleanDisabled.Value = configuration.CleanDisabled.Value;
            options.ValidateMigrationNaming.Value = configuration.ValidateMigrationNaming.Value;
            options.WorkingDirectory.Value = configuration.WorkingDirectory.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
