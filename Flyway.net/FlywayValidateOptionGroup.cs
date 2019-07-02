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

        public override string ToArgs()
        {
            var options = new StringBuilder();

            if(Url != null)
                options.Append(Url.Formatted());
            if(Driver != null)
                options.Append(Driver.Formatted());
            if(User != null)
                options.Append(User.Formatted());
            if(Password != null)
                options.Append(Password.Formatted());
            if(ConnectRetries != null)
                options.Append(ConnectRetries.Formatted());
            if(InitSql != null)
                options.Append(InitSql.Formatted());
            if(Schemas != null)
                options.Append(Schemas.Formatted());
            if(Table != null)
                options.Append(Table.Formatted());
            if(Locations != null)
                options.Append(Locations.Formatted());
            if(JarDirs != null)
                options.Append(JarDirs.Formatted());
            if(SqlMigrationPrefix != null)
                options.Append(SqlMigrationPrefix.Formatted());
            if(UndoSqlMigrationPrefix != null)
                options.Append(UndoSqlMigrationPrefix.Formatted());
            if(RepeatableSqlMigrationPrefix != null)
                options.Append(RepeatableSqlMigrationPrefix.Formatted());
            if(SqlMigrationSeparator != null)
                options.Append(SqlMigrationSeparator.Formatted());
            if(SqlMigrationSuffixes != null)
                options.Append(SqlMigrationSuffixes.Formatted());
            if(Encoding != null)
                options.Append(Encoding.Formatted());
            if(PlaceholderReplacement != null)
                options.Append(PlaceholderReplacement.Formatted());
            if(Placeholders != null)
                options.Append(Placeholders.Formatted());
            if(PlaceholderPrefix != null)
                options.Append(PlaceholderPrefix.Formatted());
            if(PlaceholderSuffix != null)
                options.Append(PlaceholderSuffix.Formatted());
            if(Resolvers != null)
                options.Append(Resolvers.Formatted());
            if(SkipDefaultResolvers != null)
                options.Append(SkipDefaultResolvers.Formatted());
            if(Callbacks != null)
                options.Append(Callbacks.Formatted());
            if(SkipDefaultCallbacks != null)
                options.Append(SkipDefaultCallbacks.Formatted());
            if(Target != null)
                options.Append(Target.Formatted());
            if(OutOfOrder != null)
                options.Append(OutOfOrder.Formatted());
            if(CleanOnValidationError != null)
                options.Append(CleanOnValidationError.Formatted());
            if(IgnoreMissingMigrations != null)
                options.Append(IgnoreMissingMigrations.Formatted());
            if(IgnoreIgnoredMigrations != null)
                options.Append(IgnoreIgnoredMigrations.Formatted());
            if(IgnoreFutureMigrations != null)
                options.Append(IgnoreFutureMigrations.Formatted());
            if(LicenseKey != null)
                options.Append(LicenseKey.Formatted());

            return options.ToString();
        }
    }
}
