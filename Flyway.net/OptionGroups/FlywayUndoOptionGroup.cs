using System.Collections.Generic;

namespace Flyway.net.OptionGroups
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/undo
    /// </summary>
    public class FlywayUndoOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywayDefaultSchemaOption DefaultSchema { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayTableOption Table { get; set; }
        public FlywayLocationsOption Locations { get; set; }
        public FlywayColorOption Color { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywaySqlMigrationPrefixOption SqlMigrationPrefix { get; set; }
        public FlywayUndoSqlMigrationPrefixOption UndoSqlMigrationPrefix { get; set; }
        public FlywayRepeatableSqlMigrationPrefixOption RepeatableSqlMigrationPrefix { get; set; }
        public FlywaySqlMigrationSeparatorOption SqlMigrationSeparator { get; set; }
        public FlywaySqlMigrationSuffixesOption SqlMigrationSuffixes { get; set; }
        public FlywayValidateMigrationNamingOption ValidateMigrationNaming { get; set; }
        public FlywayMixedOption Mixed { get; set; }
        public FlywayGroupOption Group { get; set; }
        public FlywayEncodingOption Encoding { get; set; }
        public FlywayPlaceholderReplacementOption PlaceholderReplacement { get; set; }
        public FlywayPlaceholdersOption Placeholders { get; set; }
        public FlywayPlaceholderPrefixOption PlaceholderPrefix { get; set; }
        public FlywayPlaceholderSuffixOption PlaceholderSuffix { get; set; }
        public FlywayResolversOption Resolvers { get; set; }
        public FlywaySkipDefaultResolversOption SkipDefaultResolvers { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayOutputQueryResultsOption OutputQueryResults { get; set; }
        public FlywayTargetOption Target { get; set; }
        public FlywayCleanOnValidationErrorOption CleanOnValidationError { get; set; }
        public FlywayIgnoreMissingMigrationsOption IgnoreMissingMigrations { get; set; }
        public FlywayIgnoreIgnoredMigrationsOption IgnoreIgnoredMigrations { get; set; }
        public FlywayIgnoreFutureMigrationsOption IgnoreFutureMigrations { get; set; }
        public FlywayInstalledByOption InstalledBy { get; set; }
        public FlywayErrorOverridesOption ErrorOverrides { get; set; }
        public FlywayDryRunOutputOption DryRunOutput { get; set; }
        public FlywayOracleSqlplusOption OracleSqlplus { get; set; }
        public FlywayOracleSqlplusWarnOption OracleSqlplusWarn { get; set; }
        public FlywayWorkingDirectoryOption WorkingDirectory { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayUndoOptionGroup()
        {
            Url = new FlywayUrlOption();
            Driver = new FlywayDriverOption();
            User = new FlywayUserOption();
            Password = new FlywayPasswordOption();
            ConnectRetries = new FlywayConnectRetriesOption();
            InitSql = new FlywayInitSqlOption();
            DefaultSchema = new FlywayDefaultSchemaOption();
            Schemas = new FlywaySchemasOption();
            Table = new FlywayTableOption();
            Locations = new FlywayLocationsOption();
            Color = new FlywayColorOption();
            JarDirs = new FlywayJarDirsOption();
            SqlMigrationPrefix = new FlywaySqlMigrationPrefixOption();
            UndoSqlMigrationPrefix = new FlywayUndoSqlMigrationPrefixOption();
            RepeatableSqlMigrationPrefix = new FlywayRepeatableSqlMigrationPrefixOption();
            SqlMigrationSeparator = new FlywaySqlMigrationSeparatorOption();
            SqlMigrationSuffixes = new FlywaySqlMigrationSuffixesOption();
            ValidateMigrationNaming = new FlywayValidateMigrationNamingOption();
            Mixed = new FlywayMixedOption();
            Group = new FlywayGroupOption();
            Encoding = new FlywayEncodingOption();
            PlaceholderReplacement = new FlywayPlaceholderReplacementOption();
            Placeholders = new FlywayPlaceholdersOption();
            PlaceholderPrefix = new FlywayPlaceholderPrefixOption();
            PlaceholderSuffix = new FlywayPlaceholderSuffixOption();
            Resolvers = new FlywayResolversOption();
            SkipDefaultResolvers = new FlywaySkipDefaultResolversOption();
            Callbacks = new FlywayCallbacksOption();
            SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            OutputQueryResults = new FlywayOutputQueryResultsOption();
            Target = new FlywayTargetOption();
            CleanOnValidationError = new FlywayCleanOnValidationErrorOption();
            IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption();
            IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption();
            IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption();
            InstalledBy = new FlywayInstalledByOption();
            ErrorOverrides = new FlywayErrorOverridesOption();
            DryRunOutput = new FlywayDryRunOutputOption();
            OracleSqlplus = new FlywayOracleSqlplusOption();
            OracleSqlplusWarn = new FlywayOracleSqlplusWarnOption();
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
                Table.Formatted(),
                Locations.Formatted(),
                Color.Formatted(),
                JarDirs.Formatted(),
                SqlMigrationPrefix.Formatted(),
                UndoSqlMigrationPrefix.Formatted(),
                RepeatableSqlMigrationPrefix.Formatted(),
                SqlMigrationSeparator.Formatted(),
                SqlMigrationSuffixes.Formatted(),
                ValidateMigrationNaming.Formatted(),
                Mixed.Formatted(),
                Group.Formatted(),
                Encoding.Formatted(),
                PlaceholderReplacement.Formatted(),
                Placeholders.Formatted(),
                PlaceholderPrefix.Formatted(),
                PlaceholderSuffix.Formatted(),
                SkipDefaultResolvers.Formatted(),
                Callbacks.Formatted(),
                SkipDefaultCallbacks.Formatted(),
                OutputQueryResults.Formatted(),
                Target.Formatted(),
                CleanOnValidationError.Formatted(),
                IgnoreMissingMigrations.Formatted(),
                IgnoreIgnoredMigrations.Formatted(),
                IgnoreFutureMigrations.Formatted(),
                InstalledBy.Formatted(),
                ErrorOverrides.Formatted(),
                DryRunOutput.Formatted(),
                OracleSqlplus.Formatted(),
                OracleSqlplusWarn.Formatted(),
                WorkingDirectory.Formatted(),
                LicenseKey.Formatted()
            };

            return ToArgs(options);
        }

        public static implicit operator FlywayUndoOptionGroup(FlywayConfiguration configuration)
        {
            FlywayUndoOptionGroup options = new FlywayUndoOptionGroup();
            options.Url.Value = configuration.Url.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.User.Value = configuration.User.Value;
            options.Password.Value = configuration.Password.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.DefaultSchema.Value = configuration.DefaultSchema.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.Table.Value = configuration.Table.Value;
            options.Locations.Value = configuration.Locations.Value;
            options.Color.Value = configuration.Color.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.SqlMigrationPrefix.Value = configuration.SqlMigrationPrefix.Value;
            options.UndoSqlMigrationPrefix.Value = configuration.UndoSqlMigrationPrefix.Value;
            options.RepeatableSqlMigrationPrefix.Value = configuration.RepeatableSqlMigrationPrefix.Value;
            options.SqlMigrationSeparator.Value = configuration.SqlMigrationSeparator.Value;
            options.SqlMigrationSuffixes.Value = configuration.SqlMigrationSuffixes.Value;
            options.ValidateMigrationNaming.Value = configuration.ValidateMigrationNaming.Value;
            options.Mixed.Value = configuration.Mixed.Value;
            options.Group.Value = configuration.Group.Value;
            options.Encoding.Value = configuration.Encoding.Value;
            options.PlaceholderReplacement.Value = configuration.PlaceholderReplacement.Value;
            options.Placeholders.Value = configuration.Placeholders.Value;
            options.PlaceholderPrefix.Value = configuration.PlaceholderPrefix.Value;
            options.PlaceholderSuffix.Value = configuration.PlaceholderSuffix.Value;
            options.Resolvers.Value = configuration.Resolvers.Value;
            options.SkipDefaultResolvers.Value = configuration.SkipDefaultResolvers.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.OutputQueryResults.Value = configuration.OutputQueryResults.Value;
            options.Target.Value = configuration.Target.Value;
            options.CleanOnValidationError.Value = configuration.CleanOnValidationError.Value;
            options.IgnoreMissingMigrations.Value = configuration.IgnoreMissingMigrations.Value;
            options.IgnoreIgnoredMigrations.Value = configuration.IgnoreIgnoredMigrations.Value;
            options.IgnoreFutureMigrations.Value = configuration.IgnoreFutureMigrations.Value;
            options.InstalledBy.Value = configuration.InstalledBy.Value;
            options.ErrorOverrides.Value = configuration.ErrorOverrides.Value;
            options.DryRunOutput.Value = configuration.DryRunOutput.Value;
            options.OracleSqlplus.Value = configuration.OracleSqlplus.Value;
            options.OracleSqlplusWarn.Value = configuration.OracleSqlplusWarn.Value;
            options.WorkingDirectory.Value = configuration.WorkingDirectory.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
