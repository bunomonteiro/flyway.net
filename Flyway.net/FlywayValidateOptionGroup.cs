using System.Text;

namespace Flyway.net
{
    public class FlywayValidateOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayTableOption Table { get; set; }
        public FlywayLocationsOption Locations { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywaySqlMigrationPrefixOption SqlMigrationPrefix { get; set; }
        public FlywayUndoSqlMigrationPrefixOption UndoSqlMigrationPrefix { get; set; }
        public FlywayRepeatableSqlMigrationPrefixOption RepeatableSqlMigrationPrefix { get; set; }
        public FlywaySqlMigrationSeparatorOption SqlMigrationSeparator { get; set; }
        public FlywaySqlMigrationSuffixesOption SqlMigrationSuffixes { get; set; }
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
        public FlywayCleanOnValidationErrorOption CleanOnValidationError { get; set; }
        public FlywayIgnoreMissingMigrationsOption IgnoreMissingMigrations { get; set; }
        public FlywayIgnoreIgnoredMigrationsOption IgnoreIgnoredMigrations { get; set; }
        public FlywayIgnorePendingMigrationsOption IgnorePendingMigrations { get; set; }
        public FlywayIgnoreFutureMigrationsOption IgnoreFutureMigrations { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayValidateOptionGroup()
        {
            this.Url = new FlywayUrlOption();
            this.Driver = new FlywayDriverOption();
            this.User = new FlywayUserOption();
            this.Password = new FlywayPasswordOption();
            this.ConnectRetries = new FlywayConnectRetriesOption();
            this.InitSql = new FlywayInitSqlOption();
            this.Schemas = new FlywaySchemasOption();
            this.Table = new FlywayTableOption();
            this.Locations = new FlywayLocationsOption();
            this.JarDirs = new FlywayJarDirsOption();
            this.SqlMigrationPrefix = new FlywaySqlMigrationPrefixOption();
            this.UndoSqlMigrationPrefix = new FlywayUndoSqlMigrationPrefixOption();
            this.RepeatableSqlMigrationPrefix = new FlywayRepeatableSqlMigrationPrefixOption();
            this.SqlMigrationSeparator = new FlywaySqlMigrationSeparatorOption();
            this.SqlMigrationSuffixes = new FlywaySqlMigrationSuffixesOption();
            this.Encoding = new FlywayEncodingOption();
            this.PlaceholderReplacement = new FlywayPlaceholderReplacementOption();
            this.Placeholders = new FlywayPlaceholdersOption();
            this.PlaceholderPrefix = new FlywayPlaceholderPrefixOption();
            this.PlaceholderSuffix = new FlywayPlaceholderSuffixOption();
            this.Resolvers = new FlywayResolversOption();
            this.SkipDefaultResolvers = new FlywaySkipDefaultResolversOption();
            this.Callbacks = new FlywayCallbacksOption();
            this.SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            this.Target = new FlywayTargetOption();
            this.OutOfOrder = new FlywayOutOfOrderOption();
            this.CleanOnValidationError = new FlywayCleanOnValidationErrorOption();
            this.IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption();
            this.IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption();
            this.IgnorePendingMigrations = new FlywayIgnorePendingMigrationsOption();
            this.IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption();
            this.LicenseKey = new FlywayLicenseKeyOption();
        }

        public override string ToArgs()
        {
            var options = new StringBuilder();

            if(Url != null)
                options.Append($" {Url.Formatted()}");
            if(Driver != null)
                options.Append($" {Driver.Formatted()}");
            if(User != null)
                options.Append($" {User.Formatted()}");
            if(Password != null)
                options.Append($" {Password.Formatted()}");
            if(ConnectRetries != null)
                options.Append($" {ConnectRetries.Formatted()}");
            if(InitSql != null)
                options.Append($" {InitSql.Formatted()}");
            if(Schemas != null)
                options.Append($" {Schemas.Formatted()}");
            if(Table != null)
                options.Append($" {Table.Formatted()}");
            if(Locations != null)
                options.Append($" {Locations.Formatted()}");
            if(JarDirs != null)
                options.Append($" {JarDirs.Formatted()}");
            if(SqlMigrationPrefix != null)
                options.Append($" {SqlMigrationPrefix.Formatted()}");
            if(UndoSqlMigrationPrefix != null)
                options.Append($" {UndoSqlMigrationPrefix.Formatted()}");
            if(RepeatableSqlMigrationPrefix != null)
                options.Append($" {RepeatableSqlMigrationPrefix.Formatted()}");
            if(SqlMigrationSeparator != null)
                options.Append($" {SqlMigrationSeparator.Formatted()}");
            if(SqlMigrationSuffixes != null)
                options.Append($" {SqlMigrationSuffixes.Formatted()}");
            if(Encoding != null)
                options.Append($" {Encoding.Formatted()}");
            if(PlaceholderReplacement != null)
                options.Append($" {PlaceholderReplacement.Formatted()}");
            if(Placeholders != null)
                options.Append($" {Placeholders.Formatted()}");
            if(PlaceholderPrefix != null)
                options.Append($" {PlaceholderPrefix.Formatted()}");
            if(PlaceholderSuffix != null)
                options.Append($" {PlaceholderSuffix.Formatted()}");
            if(Resolvers != null)
                options.Append($" {Resolvers.Formatted()}");
            if(SkipDefaultResolvers != null)
                options.Append($" {SkipDefaultResolvers.Formatted()}");
            if(Callbacks != null)
                options.Append($" {Callbacks.Formatted()}");
            if(SkipDefaultCallbacks != null)
                options.Append($" {SkipDefaultCallbacks.Formatted()}");
            if(Target != null)
                options.Append($" {Target.Formatted()}");
            if(OutOfOrder != null)
                options.Append($" {OutOfOrder.Formatted()}");
            if(CleanOnValidationError != null)
                options.Append($" {CleanOnValidationError.Formatted()}");
            if(IgnoreMissingMigrations != null)
                options.Append($" {IgnoreMissingMigrations.Formatted()}");
            if(IgnoreIgnoredMigrations != null)
                options.Append($" {IgnoreIgnoredMigrations.Formatted()}");
            if(IgnoreFutureMigrations != null)
                options.Append($" {IgnoreFutureMigrations.Formatted()}");
            if(LicenseKey != null)
                options.Append($" {LicenseKey.Formatted()}");

            return options.ToString();
        }

        public static implicit operator FlywayValidateOptionGroup(FlywayConfiguration configuration)
        {
            var options = new FlywayValidateOptionGroup();
            options.Url.Value = configuration.Url.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.User.Value = configuration.User.Value;
            options.Password.Value = configuration.Password.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.Table.Value = configuration.Table.Value;
            options.Locations.Value = configuration.Locations.Value;
            options.JarDirs.Value = configuration.JarDirs.Value ;
            options.SqlMigrationPrefix.Value = configuration.SqlMigrationPrefix.Value;
            options.UndoSqlMigrationPrefix.Value = configuration.UndoSqlMigrationPrefix.Value;
            options.RepeatableSqlMigrationPrefix.Value = configuration.RepeatableSqlMigrationPrefix.Value;
            options.SqlMigrationSeparator.Value = configuration.SqlMigrationSeparator.Value;
            options.SqlMigrationSuffixes.Value = configuration.SqlMigrationSuffixes.Value;
            options.Encoding.Value = configuration.Encoding.Value;
            options.PlaceholderReplacement.Value = configuration.PlaceholderReplacement.Value ;
            options.Placeholders.Value = configuration.Placeholders.Value;
            options.PlaceholderPrefix.Value = configuration.PlaceholderPrefix.Value;
            options.PlaceholderSuffix.Value = configuration.PlaceholderSuffix.Value;
            options.Resolvers.Value = configuration.Resolvers.Value;
            options.SkipDefaultResolvers.Value = configuration.SkipDefaultResolvers.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.Target.Value = configuration.Target.Value;
            options.OutOfOrder.Value = configuration.OutOfOrder.Value;
            options.CleanOnValidationError.Value = configuration.CleanOnValidationError.Value;
            options.IgnoreMissingMigrations.Value = configuration.IgnoreMissingMigrations.Value;
            options.IgnoreIgnoredMigrations.Value = configuration.IgnoreIgnoredMigrations.Value;
            options.IgnorePendingMigrations.Value = configuration.IgnorePendingMigrations.Value;
            options.IgnoreFutureMigrations.Value = configuration.IgnoreFutureMigrations.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
