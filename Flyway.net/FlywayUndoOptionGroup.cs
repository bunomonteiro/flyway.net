using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyway.net
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
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayTableOption Table { get; set; }
        public FlywayLocationsOption Locations { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywaySqlMigrationPrefixOption SqlMigrationPrefix { get; set; }
        public FlywayUndoSqlMigrationPrefixOption UndoSqlMigrationPrefix { get; set; }
        public FlywayRepeatableSqlMigrationPrefixOption RepeatableSqlMigrationPrefix { get; set; }
        public FlywaySqlMigrationSeparatorOption SqlMigrationSeparator { get; set; }
        public FlywaySqlMigrationSuffixesOption SqlMigrationSuffixes { get; set; }
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
        public FlywayIgnoreMissingMigrationsOption IgnoreMissingMigrations { get; set; }
        public FlywayIgnoreIgnoredMigrationsOption IgnoreIgnoredMigrations { get; set; }
        public FlywayIgnoreFutureMigrationsOption IgnoreFutureMigrations { get; set; }
        public FlywayInstalledByOption InstalledBy { get; set; }
        public FlywayErrorOverridesOption ErrorOverrides { get; set; }
        public FlywayDryRunOutputOption DryRunOutput { get; set; }
        public FlywayOracleSqlplusOption OracleSqlplus { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayUndoOptionGroup()
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
            this.IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption();
            this.IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption();
            this.IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption();
            this.InstalledBy = new FlywayInstalledByOption();
            this.ErrorOverrides = new FlywayErrorOverridesOption();
            this.DryRunOutput = new FlywayDryRunOutputOption();
            this.OracleSqlplus = new FlywayOracleSqlplusOption();
            this.LicenseKey = new FlywayLicenseKeyOption();
        }

        public override string ToArgs()
        {
            var options = new List<string>();

            options.Add(this.Url.Formatted());
            options.Add(this.Driver.Formatted());
            options.Add(this.User.Formatted());
            options.Add(this.Password.Formatted());
            options.Add(this.ConnectRetries.Formatted());
            options.Add(this.InitSql.Formatted());
            options.Add(this.Schemas.Formatted());
            options.Add(this.Table.Formatted());
            options.Add(this.Locations.Formatted());
            options.Add(this.JarDirs.Formatted());
            options.Add(this.SqlMigrationPrefix.Formatted());
            options.Add(this.UndoSqlMigrationPrefix.Formatted());
            options.Add(this.RepeatableSqlMigrationPrefix.Formatted());
            options.Add(this.SqlMigrationSeparator.Formatted());
            options.Add(this.SqlMigrationSuffixes.Formatted());
            options.Add(this.Mixed.Formatted());
            options.Add(this.Group.Formatted());
            options.Add(this.Encoding.Formatted());
            options.Add(this.PlaceholderReplacement.Formatted());
            options.Add(this.Placeholders.Formatted());
            options.Add(this.PlaceholderPrefix.Formatted());
            options.Add(this.PlaceholderSuffix.Formatted());
            options.Add(this.SkipDefaultResolvers.Formatted());
            options.Add(this.Callbacks.Formatted());
            options.Add(this.SkipDefaultCallbacks.Formatted());
            options.Add(this.Target.Formatted());
            options.Add(this.IgnoreMissingMigrations.Formatted());
            options.Add(this.IgnoreIgnoredMigrations.Formatted());
            options.Add(this.IgnoreFutureMigrations.Formatted());
            options.Add(this.InstalledBy.Formatted());
            options.Add(this.ErrorOverrides.Formatted());
            options.Add(this.DryRunOutput.Formatted());
            options.Add(this.OracleSqlplus.Formatted());
            options.Add(this.LicenseKey.Formatted());

            return String.Join(" ", options.Where(v => !String.IsNullOrWhiteSpace(v)).Select(v => v.Trim()));
        }

        public static implicit operator FlywayUndoOptionGroup(FlywayConfiguration configuration)
        {
            var options = new FlywayUndoOptionGroup();
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
            options.IgnoreMissingMigrations.Value = configuration.IgnoreMissingMigrations.Value;
            options.IgnoreIgnoredMigrations.Value = configuration.IgnoreIgnoredMigrations.Value;
            options.IgnoreFutureMigrations.Value = configuration.IgnoreFutureMigrations.Value;
            options.InstalledBy.Value = configuration.InstalledBy.Value;
            options.ErrorOverrides.Value = configuration.ErrorOverrides.Value;
            options.DryRunOutput.Value = configuration.DryRunOutput.Value;
            options.OracleSqlplus.Value = configuration.OracleSqlplus.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
