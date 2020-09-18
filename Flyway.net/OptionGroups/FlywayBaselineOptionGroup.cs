using System.Collections.Generic;

namespace Flyway.net.OptionGroups
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/baseline
    /// </summary>
    public class FlywayBaselineOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywayDefaultSchemaOption DefaultSchema { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayColorOption Color { get; set; }
        public FlywayTableOption Table { get; set; }
        public FlywayTableSpaceOption TableSpace { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayBaselineVersionOption BaselineVersion { get; set; }
        public FlywayBaselineDescriptionOption BaselineDescription { get; set; }
        public FlywayValidateMigrationNamingOption ValidateMigrationNaming { get; set; }
        public FlywayWorkingDirectoryOption WorkingDirectory { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayBaselineOptionGroup()
        {
            Url = new FlywayUrlOption();
            Driver = new FlywayDriverOption();
            User = new FlywayUserOption();
            Password = new FlywayPasswordOption();
            ConnectRetries = new FlywayConnectRetriesOption();
            InitSql = new FlywayInitSqlOption();
            DefaultSchema = new FlywayDefaultSchemaOption();
            Schemas = new FlywaySchemasOption();
            Color = new FlywayColorOption();
            Table = new FlywayTableOption();
            TableSpace = new FlywayTableSpaceOption();
            JarDirs = new FlywayJarDirsOption();
            Callbacks = new FlywayCallbacksOption();
            SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            BaselineVersion = new FlywayBaselineVersionOption();
            BaselineDescription = new FlywayBaselineDescriptionOption();
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
                DefaultSchema.Formatted(),
                Schemas.Formatted(),
                Color.Formatted(),
                Table.Formatted(),
                TableSpace.Formatted(),
                JarDirs.Formatted(),
                Callbacks.Formatted(),
                SkipDefaultCallbacks.Formatted(),
                BaselineVersion.Formatted(),
                BaselineDescription.Formatted(),
                ValidateMigrationNaming.Formatted(),
                WorkingDirectory.Formatted(),
                LicenseKey.Formatted()
            };

            return ToArgs(options);
        }

        public static implicit operator FlywayBaselineOptionGroup(FlywayConfiguration configuration)
        {
            if(configuration == null) { return null; }

            FlywayBaselineOptionGroup options = new FlywayBaselineOptionGroup();
            options.BaselineDescription.Value = configuration.BaselineDescription.Value;
            options.BaselineVersion.Value = configuration.BaselineVersion.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;
            options.Password.Value = configuration.Password.Value;
            options.DefaultSchema.Value = configuration.DefaultSchema.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.Color.Value = configuration.Color.Value;
            options.Table.Value = configuration.Table.Value;
            options.TableSpace.Value = configuration.TableSpace.Value;
            options.Url.Value = configuration.Url.Value;
            options.User.Value = configuration.User.Value;
            options.ValidateMigrationNaming.Value = configuration.ValidateMigrationNaming.Value;
            options.WorkingDirectory.Value = configuration.WorkingDirectory.Value;

            return options;
        }
    }
}
