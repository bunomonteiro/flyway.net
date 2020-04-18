using System;
using System.Collections.Generic;
using System.Linq;

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

        public FlywayMigrateOptionGroup()
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
            this.Stream = new FlywayStreamOption();
            this.Batch = new FlywayBatchOption();
            this.Mixed = new FlywayMixedOption();
            this.Group = new FlywayGroupOption();
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
            this.ValidateOnMigrate = new FlywayValidateOnMigrateOption();
            this.CleanOnValidationError = new FlywayCleanOnValidationErrorOption();
            this.IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption();
            this.IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption();
            this.IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption();
            this.CleanDisabled = new FlywayCleanDisabledOption();
            this.BaselineOnMigrate = new FlywayBaselineOnMigrateOption();
            this.BaselineVersion = new FlywayBaselineVersionOption();
            this.BaselineDescription = new FlywayBaselineDescriptionOption();
            this.InstalledBy = new FlywayInstalledByOption();
            this.ErrorOverrides = new FlywayErrorOverridesOption();
            this.DryRunOutput = new FlywayDryRunOutputOption();
            this.OracleSqlplus = new FlywayOracleSqlplusOption();
            this.LicenseKey = new FlywayLicenseKeyOption();
        }

        public override string ToArgs()
        {
            var options = new List<string>();

            options.Add(Url.Formatted());
            options.Add(Driver.Formatted());
            options.Add(User.Formatted());
            options.Add(Password.Formatted());
            options.Add(ConnectRetries.Formatted());
            options.Add(InitSql.Formatted());
            options.Add(Schemas.Formatted());
            options.Add(Table.Formatted());
            options.Add(Locations.Formatted());
            options.Add(JarDirs.Formatted());
            options.Add(SqlMigrationPrefix.Formatted());
            options.Add(UndoSqlMigrationPrefix.Formatted());
            options.Add(RepeatableSqlMigrationPrefix.Formatted());
            options.Add(SqlMigrationSeparator.Formatted());
            options.Add(SqlMigrationSuffixes.Formatted());
            options.Add(Stream.Formatted());
            options.Add(Batch.Formatted());
            options.Add(Mixed.Formatted());
            options.Add(Group.Formatted());
            options.Add(Encoding.Formatted());
            options.Add(PlaceholderReplacement.Formatted());
            options.Add(Placeholders.Formatted());
            options.Add(PlaceholderPrefix.Formatted());
            options.Add(PlaceholderSuffix.Formatted());
            options.Add(Resolvers.Formatted());
            options.Add(SkipDefaultResolvers.Formatted());
            options.Add(Callbacks.Formatted());
            options.Add(SkipDefaultCallbacks.Formatted());
            options.Add(Target.Formatted());
            options.Add(OutOfOrder.Formatted());
            options.Add(ValidateOnMigrate.Formatted());
            options.Add(CleanOnValidationError.Formatted());
            options.Add(IgnoreMissingMigrations.Formatted());
            options.Add(IgnoreIgnoredMigrations.Formatted());
            options.Add(IgnoreFutureMigrations.Formatted());
            options.Add(CleanDisabled.Formatted());
            options.Add(BaselineOnMigrate.Formatted());
            options.Add(BaselineVersion.Formatted());
            options.Add(BaselineDescription.Formatted());
            options.Add(InstalledBy.Formatted());
            options.Add(ErrorOverrides.Formatted());
            options.Add(DryRunOutput.Formatted());
            options.Add(OracleSqlplus.Formatted());
            options.Add(LicenseKey.Formatted());

            return String.Join(" ", options.Where(v => !String.IsNullOrWhiteSpace(v)).Select(v => v.Trim()));
        }

        public static implicit operator FlywayMigrateOptionGroup(FlywayConfiguration configuration)
        {
            var options = new FlywayMigrateOptionGroup();
            options.Url.Value = configuration.Url.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.User.Value = configuration.User.Value;
            options.Password.Value = configuration.Password.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.Table.Value = configuration.Table.Value;
            options.Locations.Value = configuration.Locations.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.SqlMigrationPrefix.Value = configuration.SqlMigrationPrefix.Value;
            options.UndoSqlMigrationPrefix.Value = configuration.UndoSqlMigrationPrefix.Value;
            options.RepeatableSqlMigrationPrefix.Value = configuration.RepeatableSqlMigrationPrefix.Value;
            options.SqlMigrationSeparator.Value = configuration.SqlMigrationSeparator.Value;
            options.SqlMigrationSuffixes.Value = configuration.SqlMigrationSuffixes.Value;
            options.Stream.Value = configuration.Stream.Value;
            options.Batch.Value = configuration.Batch.Value;
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
            options.Target.Value = configuration.Target.Value;
            options.OutOfOrder.Value = configuration.OutOfOrder.Value;
            options.ValidateOnMigrate.Value = configuration.ValidateOnMigrate.Value;
            options.CleanOnValidationError.Value = configuration.CleanOnValidationError.Value;
            options.IgnoreMissingMigrations.Value = configuration.IgnoreMissingMigrations.Value;
            options.IgnoreIgnoredMigrations.Value = configuration.IgnoreIgnoredMigrations.Value;
            options.IgnoreFutureMigrations.Value = configuration.IgnoreFutureMigrations.Value;
            options.CleanDisabled.Value = configuration.CleanDisabled.Value;
            options.BaselineOnMigrate.Value = configuration.BaselineOnMigrate.Value;
            options.BaselineVersion.Value = configuration.BaselineVersion.Value;
            options.BaselineDescription.Value = configuration.BaselineDescription.Value;
            options.InstalledBy.Value = configuration.InstalledBy.Value;
            options.ErrorOverrides.Value = configuration.ErrorOverrides.Value;
            options.DryRunOutput.Value = configuration.DryRunOutput.Value;
            options.OracleSqlplus.Value = configuration.OracleSqlplus.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
