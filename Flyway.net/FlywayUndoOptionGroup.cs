using System;
using System.Collections.Generic;
using System.Text;

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
            var options = new StringBuilder();

            if(Url != null)
                options.Append($" {Url}");
            if(Driver != null)
                options.Append($" {Driver}");
            if(User != null)
                options.Append($" {User}");
            if(Password != null)
                options.Append($" {Password}");
            if(ConnectRetries != null)
                options.Append($" {ConnectRetries}");
            if(InitSql != null)
                options.Append($" {InitSql}");
            if(Schemas != null)
                options.Append($" {Schemas}");
            if(Table != null)
                options.Append($" {Table}");
            if(Locations != null)
                options.Append($" {Locations}");
            if(JarDirs != null)
                options.Append($" {JarDirs}");
            if(SqlMigrationPrefix != null)
                options.Append($" {SqlMigrationPrefix}");
            if(UndoSqlMigrationPrefix != null)
                options.Append($" {UndoSqlMigrationPrefix}");
            if(RepeatableSqlMigrationPrefix != null)
                options.Append($" {RepeatableSqlMigrationPrefix}");
            if(SqlMigrationSeparator != null)
                options.Append($" {SqlMigrationSeparator}");
            if(SqlMigrationSuffixes != null)
                options.Append($" {SqlMigrationSuffixes}");
            if(Mixed != null)
                options.Append($" {Mixed}");
            if(Group != null)
                options.Append($" {Group}");
            if(Encoding != null)
                options.Append($" {Encoding}");
            if(PlaceholderReplacement != null)
                options.Append($" {PlaceholderReplacement}");
            if(Placeholders != null)
                options.Append($" {Placeholders}");
            if(PlaceholderPrefix != null)
                options.Append($" {PlaceholderPrefix}");
            if(PlaceholderSuffix != null)
                options.Append($" {PlaceholderSuffix}");
            if(Resolvers != null)
                options.Append($" {Resolvers}");
            if(SkipDefaultResolvers != null)
                options.Append($" {SkipDefaultResolvers}");
            if(Callbacks != null)
                options.Append($" {Callbacks}");
            if(SkipDefaultCallbacks != null)
                options.Append($" {SkipDefaultCallbacks}");
            if(Target != null)
                options.Append($" {Target}");
            if(IgnoreMissingMigrations != null)
                options.Append($" {IgnoreMissingMigrations}");
            if(IgnoreIgnoredMigrations != null)
                options.Append($" {IgnoreIgnoredMigrations}");
            if(IgnoreFutureMigrations != null)
                options.Append($" {IgnoreFutureMigrations}");
            if(InstalledBy != null)
                options.Append($" {InstalledBy}");
            if(ErrorOverrides != null)
                options.Append($" {ErrorOverrides}");
            if(DryRunOutput != null)
                options.Append($" {DryRunOutput}");
            if(OracleSqlplus != null)
                options.Append($" {OracleSqlplus}");
            if(LicenseKey != null)
                options.Append($" {LicenseKey}");

            return options.ToString();
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
