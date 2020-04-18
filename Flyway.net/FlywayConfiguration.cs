using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Flyway.net
{
    public class FlywayConfiguration
    {
        #region keys
        public string ConfigurationFilePath { get; set; }
        public FlywayUrlOption Url { get; private set; }
        public FlywayDriverOption Driver { get; private set; }
        public FlywayUserOption User { get; private set; }
        public FlywayPasswordOption Password { get; private set; }
        public FlywayConnectRetriesOption ConnectRetries { get; private set; }
        public FlywayInitSqlOption InitSql { get; private set; }
        public FlywaySchemasOption Schemas { get; private set; }
        public FlywayTableOption Table { get; private set; }
        public FlywayLocationsOption Locations { get; private set; }
        public FlywayResolversOption Resolvers { get; private set; }
        public FlywaySkipDefaultResolversOption SkipDefaultResolvers { get; private set; }
        public FlywayJarDirsOption JarDirs { get; private set; }
        public FlywaySqlMigrationPrefixOption SqlMigrationPrefix { get; private set; }
        public FlywayUndoSqlMigrationPrefixOption UndoSqlMigrationPrefix { get; private set; }
        public FlywayRepeatableSqlMigrationPrefixOption RepeatableSqlMigrationPrefix { get; private set; }
        public FlywaySqlMigrationSeparatorOption SqlMigrationSeparator { get; private set; }
        public FlywaySqlMigrationSuffixesOption SqlMigrationSuffixes { get; private set; }
        public FlywayStreamOption Stream { get; private set; }
        public FlywayBatchOption Batch { get; private set; }
        public FlywayPlaceholderReplacementOption PlaceholderReplacement { get; private set; }
        public FlywayPlaceholdersOption Placeholders { get; private set; }
        public FlywayPlaceholderPrefixOption PlaceholderPrefix { get; private set; }
        public FlywayPlaceholderSuffixOption PlaceholderSuffix { get; private set; }
        public FlywayTargetOption Target { get; private set; }
        public FlywayValidateOnMigrateOption ValidateOnMigrate { get; private set; }
        public FlywayCleanOnValidationErrorOption CleanOnValidationError { get; private set; }
        public FlywayCleanDisabledOption CleanDisabled { get; private set; }
        public FlywayBaselineVersionOption BaselineVersion { get; private set; }
        public FlywayBaselineDescriptionOption BaselineDescription { get; private set; }
        public FlywayBaselineOnMigrateOption BaselineOnMigrate { get; private set; }
        public FlywayOutOfOrderOption OutOfOrder { get; private set; }
        public FlywayCallbacksOption Callbacks { get; private set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; private set; }
        public FlywayIgnoreMissingMigrationsOption IgnoreMissingMigrations { get; private set; }
        public FlywayIgnoreIgnoredMigrationsOption IgnoreIgnoredMigrations { get; private set; }
        public FlywayIgnorePendingMigrationsOption IgnorePendingMigrations { get; private set; }
        public FlywayIgnoreFutureMigrationsOption IgnoreFutureMigrations { get; private set; }
        public FlywayMixedOption Mixed { get; private set; }
        public FlywayGroupOption Group { get; private set; }
        public FlywayInstalledByOption InstalledBy { get; private set; }
        public FlywayErrorOverridesOption ErrorOverrides { get; private set; }
        public FlywayDryRunOutputOption DryRunOutput { get; private set; }
        public FlywayOracleSqlplusOption OracleSqlplus { get; private set; }
        public FlywayEncodingOption Encoding { get; private set; }
        public FlywayLicenseKeyOption LicenseKey { get; private set; }
        #endregion

        private Action<string, string> Saver { get; set; }
        private Func<string, string[]> Loader { get; set; }
        private bool IsInMemory { get; set; }

        public FlywayConfiguration(string configurationFilePath = null) : this(File.WriteAllText, File.ReadAllLines, configurationFilePath) { }
        public FlywayConfiguration(Action<string, string> saver, Func<string, string[]> loader, string configurationFilePath = null)
        {
            if(saver is null)
            {
                throw new ArgumentNullException(nameof(saver));
            }

            if(loader is null)
            {
                throw new ArgumentNullException(nameof(loader));
            }

            this.ConfigurationFilePath = configurationFilePath;
            this.Saver = saver;
            this.Loader = loader;

            this.IsInMemory = String.IsNullOrWhiteSpace(ConfigurationFilePath);

            Prefix prefix = IsInMemory ? Prefix.Cli : Prefix.File;

            this.Url = new FlywayUrlOption(prefix: prefix);
            this.Driver = new FlywayDriverOption(prefix: prefix);
            this.User = new FlywayUserOption(prefix: prefix);
            this.Password = new FlywayPasswordOption(prefix: prefix);
            this.ConnectRetries = new FlywayConnectRetriesOption(prefix: prefix);
            this.InitSql = new FlywayInitSqlOption(prefix: prefix);
            this.Schemas = new FlywaySchemasOption(prefix: prefix);
            this.Table = new FlywayTableOption(prefix: prefix);
            this.Locations = new FlywayLocationsOption(prefix: prefix);
            this.Resolvers = new FlywayResolversOption(prefix: prefix);
            this.SkipDefaultResolvers = new FlywaySkipDefaultResolversOption(prefix: prefix);
            this.JarDirs = new FlywayJarDirsOption(prefix: prefix);
            this.SqlMigrationPrefix = new FlywaySqlMigrationPrefixOption(prefix: prefix);
            this.UndoSqlMigrationPrefix = new FlywayUndoSqlMigrationPrefixOption(prefix: prefix);
            this.RepeatableSqlMigrationPrefix = new FlywayRepeatableSqlMigrationPrefixOption(prefix: prefix);
            this.SqlMigrationSeparator = new FlywaySqlMigrationSeparatorOption(prefix: prefix);
            this.SqlMigrationSuffixes = new FlywaySqlMigrationSuffixesOption(prefix: prefix);
            this.Stream = new FlywayStreamOption(prefix: prefix);
            this.Batch = new FlywayBatchOption(prefix: prefix);
            this.PlaceholderReplacement = new FlywayPlaceholderReplacementOption(prefix: prefix);
            this.Placeholders = new FlywayPlaceholdersOption(prefix: prefix);
            this.PlaceholderPrefix = new FlywayPlaceholderPrefixOption(prefix: prefix);
            this.PlaceholderSuffix = new FlywayPlaceholderSuffixOption(prefix: prefix);
            this.Target = new FlywayTargetOption(prefix: prefix);
            this.ValidateOnMigrate = new FlywayValidateOnMigrateOption(prefix: prefix);
            this.CleanOnValidationError = new FlywayCleanOnValidationErrorOption(prefix: prefix);
            this.CleanDisabled = new FlywayCleanDisabledOption(prefix: prefix);
            this.BaselineVersion = new FlywayBaselineVersionOption(prefix: prefix);
            this.BaselineDescription = new FlywayBaselineDescriptionOption(prefix: prefix);
            this.BaselineOnMigrate = new FlywayBaselineOnMigrateOption(prefix: prefix);
            this.OutOfOrder = new FlywayOutOfOrderOption(prefix: prefix);
            this.Callbacks = new FlywayCallbacksOption(prefix: prefix);
            this.SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption(prefix: prefix);
            this.IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption(prefix: prefix);
            this.IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption(prefix: prefix);
            this.IgnorePendingMigrations = new FlywayIgnorePendingMigrationsOption(prefix: prefix);
            this.IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption(prefix: prefix);
            this.Mixed = new FlywayMixedOption(prefix: prefix);
            this.Group = new FlywayGroupOption(prefix: prefix);
            this.InstalledBy = new FlywayInstalledByOption(prefix: prefix);
            this.ErrorOverrides = new FlywayErrorOverridesOption(prefix: prefix);
            this.DryRunOutput = new FlywayDryRunOutputOption(prefix: prefix);
            this.OracleSqlplus = new FlywayOracleSqlplusOption(prefix: prefix);
            this.Encoding = new FlywayEncodingOption(prefix: prefix);
            this.LicenseKey = new FlywayLicenseKeyOption(prefix: prefix);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        private T ReadValue<T>(string line)
        {
            try
            {
                Type type = typeof(T);
                type = Nullable.GetUnderlyingType(type) ?? type;

                var config = line.Substring(line.IndexOf("=") + 1).Trim();

                if(String.IsNullOrWhiteSpace(config))
                {
                    return default;
                }

                if(type == typeof(bool?) || type == typeof(bool))
                {
                    config = config.ToLower();
                }

                return (T)Convert.ChangeType(config, type);
            } catch(Exception)
            {
                return default;
            }
        }
        public FlywayConfiguration Load()
        {
            if(this.IsInMemory) return this;

            var configLines = this.Loader(this.ConfigurationFilePath);

            string line;
            for(int i = 0; i < configLines.Length; i++)
            {
                line = configLines[i].Trim();

                if(String.IsNullOrWhiteSpace(line)) continue;
                else if(line.StartsWith(this.Url.FullName)) this.Url.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Driver.FullName)) this.Driver.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.User.FullName)) this.User.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Password.FullName)) this.Password.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.ConnectRetries.FullName)) this.ConnectRetries.Value = ReadValue<ushort?>(line);
                else if(line.StartsWith(this.InitSql.FullName)) this.InitSql.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Schemas.FullName)) this.Schemas.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Table.FullName)) this.Table.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Locations.FullName)) this.Locations.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Resolvers.FullName)) this.Resolvers.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.SkipDefaultResolvers.FullName)) this.SkipDefaultResolvers.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.JarDirs.FullName)) this.JarDirs.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.SqlMigrationPrefix.FullName)) this.SqlMigrationPrefix.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.UndoSqlMigrationPrefix.FullName)) this.UndoSqlMigrationPrefix.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.RepeatableSqlMigrationPrefix.FullName)) this.RepeatableSqlMigrationPrefix.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.SqlMigrationSeparator.FullName)) this.SqlMigrationSeparator.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.SqlMigrationSuffixes.FullName)) this.SqlMigrationSuffixes.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Stream.FullName)) this.Stream.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.Batch.FullName)) this.Batch.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.PlaceholderReplacement.FullName)) this.PlaceholderReplacement.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.Placeholders.FullName)) this.Placeholders.Value = ReadValue<Dictionary<string, string>>(line);
                else if(line.StartsWith(this.PlaceholderPrefix.FullName)) this.PlaceholderPrefix.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.PlaceholderSuffix.FullName)) this.PlaceholderSuffix.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Target.FullName)) this.Target.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.ValidateOnMigrate.FullName)) this.ValidateOnMigrate.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.CleanOnValidationError.FullName)) this.CleanOnValidationError.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.CleanDisabled.FullName)) this.CleanDisabled.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.BaselineVersion.FullName)) this.BaselineVersion.Value = ReadValue<uint?>(line);
                else if(line.StartsWith(this.BaselineDescription.FullName)) this.BaselineDescription.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.BaselineOnMigrate.FullName)) this.BaselineOnMigrate.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.OutOfOrder.FullName)) this.OutOfOrder.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.Callbacks.FullName)) this.Callbacks.Value = ReadValue<List<string>>(line);
                else if(line.StartsWith(this.SkipDefaultCallbacks.FullName)) this.SkipDefaultCallbacks.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.IgnoreMissingMigrations.FullName)) this.IgnoreMissingMigrations.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.IgnoreIgnoredMigrations.FullName)) this.IgnoreIgnoredMigrations.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.IgnorePendingMigrations.FullName)) this.IgnorePendingMigrations.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.IgnoreFutureMigrations.FullName)) this.IgnoreFutureMigrations.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.Mixed.FullName)) this.Mixed.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.Group.FullName)) this.Group.Value = ReadValue<bool?>(line);
                else if(line.StartsWith(this.InstalledBy.FullName)) this.InstalledBy.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.ErrorOverrides.FullName)) this.ErrorOverrides.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.DryRunOutput.FullName)) this.DryRunOutput.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.OracleSqlplus.FullName)) this.OracleSqlplus.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.Encoding.FullName)) this.Encoding.Value = ReadValue<string>(line);
                else if(line.StartsWith(this.LicenseKey.FullName)) this.LicenseKey.Value = ReadValue<string>(line);
            }

            return this;
        }

        public void Save()
        {
            if(!this.IsInMemory)
            {
                this.Saver(this.ConfigurationFilePath, Regex.Replace(this.ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline));
            }
        }

        public override string ToString()
        {
            var config = new StringBuilder();
            config.AppendLine(this.Url.Formatted());
            config.AppendLine(this.Driver.Formatted());
            config.AppendLine(this.User.Formatted());
            config.AppendLine(this.Password.Formatted());
            config.AppendLine(this.ConnectRetries.Formatted());
            config.AppendLine(this.InitSql.Formatted());
            config.AppendLine(this.Schemas.Formatted());
            config.AppendLine(this.Table.Formatted());
            config.AppendLine(this.Locations.Formatted());
            config.AppendLine(this.Resolvers.Formatted());
            config.AppendLine(this.SkipDefaultResolvers.Formatted());
            config.AppendLine(this.JarDirs.Formatted());
            config.AppendLine(this.SqlMigrationPrefix.Formatted());
            config.AppendLine(this.UndoSqlMigrationPrefix.Formatted());
            config.AppendLine(this.RepeatableSqlMigrationPrefix.Formatted());
            config.AppendLine(this.SqlMigrationSeparator.Formatted());
            config.AppendLine(this.SqlMigrationSuffixes.Formatted());
            config.AppendLine(this.Stream.Formatted());
            config.AppendLine(this.Batch.Formatted());
            config.AppendLine(this.PlaceholderReplacement.Formatted());
            config.AppendLine(this.Placeholders.Formatted());
            config.AppendLine(this.PlaceholderPrefix.Formatted());
            config.AppendLine(this.PlaceholderSuffix.Formatted());
            config.AppendLine(this.Target.Formatted());
            config.AppendLine(this.ValidateOnMigrate.Formatted());
            config.AppendLine(this.CleanOnValidationError.Formatted());
            config.AppendLine(this.CleanDisabled.Formatted());
            config.AppendLine(this.BaselineVersion.Formatted());
            config.AppendLine(this.BaselineDescription.Formatted());
            config.AppendLine(this.BaselineOnMigrate.Formatted());
            config.AppendLine(this.OutOfOrder.Formatted());
            config.AppendLine(this.Callbacks.Formatted());
            config.AppendLine(this.SkipDefaultCallbacks.Formatted());
            config.AppendLine(this.IgnoreMissingMigrations.Formatted());
            config.AppendLine(this.IgnoreIgnoredMigrations.Formatted());
            config.AppendLine(this.IgnorePendingMigrations.Formatted());
            config.AppendLine(this.IgnoreFutureMigrations.Formatted());
            config.AppendLine(this.Mixed.Formatted());
            config.AppendLine(this.Group.Formatted());
            config.AppendLine(this.InstalledBy.Formatted());
            config.AppendLine(this.ErrorOverrides.Formatted());
            config.AppendLine(this.DryRunOutput.Formatted());
            config.AppendLine(this.OracleSqlplus.Formatted());
            config.AppendLine(this.Encoding.Formatted());
            config.AppendLine(this.LicenseKey.Formatted());

            return config.ToString().Trim();
        }
    }
}
