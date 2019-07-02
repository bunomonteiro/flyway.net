using System.Text;

namespace Flyway.net
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/migrate
    /// </summary>
    public class FlywayMigrateOptionGroup : FlywayOptionGroup
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
        public FlywayStreamOption Stream { get; set; }
        public FlywayBatchOption Batch { get; set; }
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
        public FlywayTargetOption Target { get; set; }
        public FlywayOutOfOrderOption OutOfOrder { get; set; }
        public FlywayValidateOnMigrateOption ValidateOnMigrate { get; set; }
        public FlywayCleanOnValidationErrorOption CleanOnValidationError { get; set; }
        public FlywayIgnoreMissingMigrationsOption IgnoreMissingMigrations { get; set; }
        public FlywayIgnoreIgnoredMigrationsOption IgnoreIgnoredMigrations { get; set; }
        public FlywayIgnoreFutureMigrationsOption IgnoreFutureMigrations { get; set; }
        public FlywayCleanDisabledOption CleanDisabled { get; set; }
        public FlywayBaselineOnMigrateOption BaselineOnMigrate { get; set; }
        public FlywayBaselineVersionOption BaselineVersion { get; set; }
        public FlywayBaselineDescriptionOption BaselineDescription { get; set; }
        public FlywayInstalledByOption InstalledBy { get; set; }
        public FlywayErrorOverridesOption ErrorOverrides { get; set; }
        public FlywayDryRunOutputOption DryRunOutput { get; set; }
        public FlywayOracleSqlplusOption OracleSqlplus { get; set; }
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
            if(Stream != null)
                options.Append(Stream.Formatted());
            if(Batch != null)
                options.Append(Batch.Formatted());
            if(Mixed != null)
                options.Append(Mixed.Formatted());
            if(Group != null)
                options.Append(Group.Formatted());
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
            if(ValidateOnMigrate != null)
                options.Append(ValidateOnMigrate.Formatted());
            if(CleanOnValidationError != null)
                options.Append(CleanOnValidationError.Formatted());
            if(IgnoreMissingMigrations != null)
                options.Append(IgnoreMissingMigrations.Formatted());
            if(IgnoreIgnoredMigrations != null)
                options.Append(IgnoreIgnoredMigrations.Formatted());
            if(IgnoreFutureMigrations != null)
                options.Append(IgnoreFutureMigrations.Formatted());
            if(CleanDisabled != null)
                options.Append(CleanDisabled.Formatted());
            if(BaselineOnMigrate != null)
                options.Append(BaselineOnMigrate.Formatted());
            if(BaselineVersion != null)
                options.Append(BaselineVersion.Formatted());
            if(BaselineDescription != null)
                options.Append(BaselineDescription.Formatted());
            if(InstalledBy != null)
                options.Append(InstalledBy.Formatted());
            if(ErrorOverrides != null)
                options.Append(ErrorOverrides.Formatted());
            if(DryRunOutput != null)
                options.Append(DryRunOutput.Formatted());
            if(OracleSqlplus != null)
                options.Append(OracleSqlplus.Formatted());
            if(LicenseKey != null)
                options.Append(LicenseKey.Formatted());

            return options.ToString();
        }
    }
}
