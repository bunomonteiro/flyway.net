using System.Collections.Generic;

namespace Flyway.net.OptionGroups
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/info
    /// </summary>
    public class FlywayInfoOptionGroup : FlywayOptionGroup
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
        public FlywayEncodingOption Encoding { get; set; }
        public FlywayPlaceholderReplacementOption PlaceholderReplacement { get; set; }
        public FlywayPlaceholdersOption Placeholders { get; set; }
        public FlywayPlaceholderPrefixOption PlaceholderPrefix { get; set; }
        public FlywayPlaceholderSuffixOption PlaceholderSuffix { get; set; }
        public FlywayResolversOption Resolvers { get; set; }
        public FlywaySkipDefaultResolversOption SkipDefaultResolvers { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayTargetOption Target { get; set; }
        public FlywayOutOfOrderOption OutOfOrder { get; set; }
        public FlywayWorkingDirectoryOption WorkingDirectory { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayInfoOptionGroup()
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
            Encoding = new FlywayEncodingOption();
            PlaceholderReplacement = new FlywayPlaceholderReplacementOption();
            Placeholders = new FlywayPlaceholdersOption();
            PlaceholderPrefix = new FlywayPlaceholderPrefixOption();
            PlaceholderSuffix = new FlywayPlaceholderSuffixOption();
            Resolvers = new FlywayResolversOption();
            SkipDefaultResolvers = new FlywaySkipDefaultResolversOption();
            Callbacks = new FlywayCallbacksOption();
            SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            Target = new FlywayTargetOption();
            OutOfOrder = new FlywayOutOfOrderOption();
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
                Encoding.Formatted(),
                PlaceholderReplacement.Formatted(),
                Placeholders.Formatted(),
                PlaceholderPrefix.Formatted(),
                PlaceholderSuffix.Formatted(),
                Resolvers.Formatted(),
                SkipDefaultResolvers.Formatted(),
                Callbacks.Formatted(),
                SkipDefaultCallbacks.Formatted(),
                Target.Formatted(),
                OutOfOrder.Formatted(),
                WorkingDirectory.Formatted(),
                LicenseKey.Formatted()
            };

            return ToArgs(options);
        }

        public static implicit operator FlywayInfoOptionGroup(FlywayConfiguration configuration)
        {
            if(configuration == null) { return null; }

            FlywayInfoOptionGroup options = new FlywayInfoOptionGroup();
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
            options.Encoding.Value = configuration.Encoding.Value;
            options.PlaceholderReplacement.Value = configuration.PlaceholderReplacement.Value;
            options.Placeholders.Value = configuration.Placeholders.Value;
            options.PlaceholderPrefix.Value = configuration.PlaceholderPrefix.Value;
            options.PlaceholderSuffix.Value = configuration.PlaceholderSuffix.Value;
            options.Resolvers.Value = configuration.Resolvers.Value;
            options.SkipDefaultResolvers.Value = configuration.SkipDefaultResolvers.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.Target.Value = configuration.Target.Value;
            options.OutOfOrder.Value = configuration.OutOfOrder.Value;
            options.WorkingDirectory.Value = configuration.WorkingDirectory.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
