using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Flyway.net.ValueObjects;

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

            ConfigurationFilePath = configurationFilePath;
            Saver = saver;
            Loader = loader;

            IsInMemory = string.IsNullOrWhiteSpace(ConfigurationFilePath);

            Prefix prefix = IsInMemory ? Prefix.Cli : Prefix.File;

            Url = new FlywayUrlOption(prefix: prefix);
            Driver = new FlywayDriverOption(prefix: prefix);
            User = new FlywayUserOption(prefix: prefix);
            Password = new FlywayPasswordOption(prefix: prefix);
            ConnectRetries = new FlywayConnectRetriesOption(prefix: prefix);
            InitSql = new FlywayInitSqlOption(prefix: prefix);
            Schemas = new FlywaySchemasOption(prefix: prefix);
            Table = new FlywayTableOption(prefix: prefix);
            Locations = new FlywayLocationsOption(prefix: prefix);
            Resolvers = new FlywayResolversOption(prefix: prefix);
            SkipDefaultResolvers = new FlywaySkipDefaultResolversOption(prefix: prefix);
            JarDirs = new FlywayJarDirsOption(prefix: prefix);
            SqlMigrationPrefix = new FlywaySqlMigrationPrefixOption(prefix: prefix);
            UndoSqlMigrationPrefix = new FlywayUndoSqlMigrationPrefixOption(prefix: prefix);
            RepeatableSqlMigrationPrefix = new FlywayRepeatableSqlMigrationPrefixOption(prefix: prefix);
            SqlMigrationSeparator = new FlywaySqlMigrationSeparatorOption(prefix: prefix);
            SqlMigrationSuffixes = new FlywaySqlMigrationSuffixesOption(prefix: prefix);
            Stream = new FlywayStreamOption(prefix: prefix);
            Batch = new FlywayBatchOption(prefix: prefix);
            PlaceholderReplacement = new FlywayPlaceholderReplacementOption(prefix: prefix);
            Placeholders = new FlywayPlaceholdersOption(prefix: prefix);
            PlaceholderPrefix = new FlywayPlaceholderPrefixOption(prefix: prefix);
            PlaceholderSuffix = new FlywayPlaceholderSuffixOption(prefix: prefix);
            Target = new FlywayTargetOption(prefix: prefix);
            ValidateOnMigrate = new FlywayValidateOnMigrateOption(prefix: prefix);
            CleanOnValidationError = new FlywayCleanOnValidationErrorOption(prefix: prefix);
            CleanDisabled = new FlywayCleanDisabledOption(prefix: prefix);
            BaselineVersion = new FlywayBaselineVersionOption(prefix: prefix);
            BaselineDescription = new FlywayBaselineDescriptionOption(prefix: prefix);
            BaselineOnMigrate = new FlywayBaselineOnMigrateOption(prefix: prefix);
            OutOfOrder = new FlywayOutOfOrderOption(prefix: prefix);
            Callbacks = new FlywayCallbacksOption(prefix: prefix);
            SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption(prefix: prefix);
            IgnoreMissingMigrations = new FlywayIgnoreMissingMigrationsOption(prefix: prefix);
            IgnoreIgnoredMigrations = new FlywayIgnoreIgnoredMigrationsOption(prefix: prefix);
            IgnorePendingMigrations = new FlywayIgnorePendingMigrationsOption(prefix: prefix);
            IgnoreFutureMigrations = new FlywayIgnoreFutureMigrationsOption(prefix: prefix);
            Mixed = new FlywayMixedOption(prefix: prefix);
            Group = new FlywayGroupOption(prefix: prefix);
            InstalledBy = new FlywayInstalledByOption(prefix: prefix);
            ErrorOverrides = new FlywayErrorOverridesOption(prefix: prefix);
            DryRunOutput = new FlywayDryRunOutputOption(prefix: prefix);
            OracleSqlplus = new FlywayOracleSqlplusOption(prefix: prefix);
            Encoding = new FlywayEncodingOption(prefix: prefix);
            LicenseKey = new FlywayLicenseKeyOption(prefix: prefix);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        private T ReadValue<T>(string line)
        {
            try
            {
                Type type = typeof(T);
                type = Nullable.GetUnderlyingType(type) ?? type;

                string config = line.Substring(line.IndexOf("=") + 1).Trim();

                if(string.IsNullOrWhiteSpace(config))
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        private void ReadKeyValuePairValue<TKey, TValue>(FlywayDictionaryOption<TKey, TValue> option, string line)
        {
            try
            {
                Type keyType = typeof(TKey);
                keyType = Nullable.GetUnderlyingType(keyType) ?? keyType;
                string keyLine = line.Substring(option.FullName.Length + 1);
                string key = keyLine.Substring(0, keyLine.IndexOf("=")).Trim();

                if(string.IsNullOrWhiteSpace(key))
                {
                    return;
                }

                if(keyType == typeof(bool?) || keyType == typeof(bool))
                {
                    key = key.ToLower();
                }

                option.Value.Add((TKey)Convert.ChangeType(key, keyType), ReadValue<TValue>(line));
            } catch(Exception)
            {
                return;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        private List<T> ReadListValue<T>(string line)
        {
            try
            {
                Type type = typeof(T);
                type = Nullable.GetUnderlyingType(type) ?? type;

                string config = line.Substring(line.IndexOf("=") + 1).Trim();

                if(string.IsNullOrWhiteSpace(config))
                {
                    return default;
                }

                if(type == typeof(bool?) || type == typeof(bool))
                {
                    config = config.ToLower();
                }

                return (List<T>)Convert.ChangeType(config.Split(',').ToList().OfType<T>().ToList(), typeof(List<T>));

            } catch(Exception)
            {
                return default;
            }
        }

        public FlywayConfiguration Load()
        {
            if(IsInMemory)
            {
                return this;
            }

            string[] configLines = Loader(ConfigurationFilePath);

            string line;
            for(int i = 0; i < configLines.Length; i++)
            {
                line = configLines[i].Trim();

                if(string.IsNullOrWhiteSpace(line))
                {
                    continue;
                } else if(line.StartsWith(Url.FullName))
                {
                    Url.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Driver.FullName))
                {
                    Driver.Value = ReadValue<string>(line);
                } else if(line.StartsWith(User.FullName))
                {
                    User.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Password.FullName))
                {
                    Password.Value = ReadValue<string>(line);
                } else if(line.StartsWith(ConnectRetries.FullName))
                {
                    ConnectRetries.Value = ReadValue<ushort?>(line);
                } else if(line.StartsWith(InitSql.FullName))
                {
                    InitSql.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Schemas.FullName))
                {
                    Schemas.Value = ReadListValue<string>(line);
                } else if(line.StartsWith(Table.FullName))
                {
                    Table.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Locations.FullName))
                {
                    Locations.Value = ReadListValue<string>(line);
                } else if(line.StartsWith(Resolvers.FullName))
                {
                    Resolvers.Value = ReadValue<string>(line);
                } else if(line.StartsWith(SkipDefaultResolvers.FullName))
                {
                    SkipDefaultResolvers.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(JarDirs.FullName))
                {
                    JarDirs.Value = ReadValue<string>(line);
                } else if(line.StartsWith(SqlMigrationPrefix.FullName))
                {
                    SqlMigrationPrefix.Value = ReadValue<string>(line);
                } else if(line.StartsWith(UndoSqlMigrationPrefix.FullName))
                {
                    UndoSqlMigrationPrefix.Value = ReadValue<string>(line);
                } else if(line.StartsWith(RepeatableSqlMigrationPrefix.FullName))
                {
                    RepeatableSqlMigrationPrefix.Value = ReadValue<string>(line);
                } else if(line.StartsWith(SqlMigrationSeparator.FullName))
                {
                    SqlMigrationSeparator.Value = ReadValue<string>(line);
                } else if(line.StartsWith(SqlMigrationSuffixes.FullName))
                {
                    SqlMigrationSuffixes.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Stream.FullName))
                {
                    Stream.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(Batch.FullName))
                {
                    Batch.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(PlaceholderReplacement.FullName))
                {
                    PlaceholderReplacement.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(Placeholders.FullName))
                {
                    ReadKeyValuePairValue(Placeholders, line);
                } else if(line.StartsWith(PlaceholderPrefix.FullName))
                {
                    PlaceholderPrefix.Value = ReadValue<string>(line);
                } else if(line.StartsWith(PlaceholderSuffix.FullName))
                {
                    PlaceholderSuffix.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Target.FullName))
                {
                    Target.Value = ReadValue<string>(line);
                } else if(line.StartsWith(ValidateOnMigrate.FullName))
                {
                    ValidateOnMigrate.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(CleanOnValidationError.FullName))
                {
                    CleanOnValidationError.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(CleanDisabled.FullName))
                {
                    CleanDisabled.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(BaselineVersion.FullName))
                {
                    BaselineVersion.Value = ReadValue<uint?>(line);
                } else if(line.StartsWith(BaselineDescription.FullName))
                {
                    BaselineDescription.Value = ReadValue<string>(line);
                } else if(line.StartsWith(BaselineOnMigrate.FullName))
                {
                    BaselineOnMigrate.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(OutOfOrder.FullName))
                {
                    OutOfOrder.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(Callbacks.FullName))
                {
                    Callbacks.Value = ReadListValue<string>(line);
                } else if(line.StartsWith(SkipDefaultCallbacks.FullName))
                {
                    SkipDefaultCallbacks.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(IgnoreMissingMigrations.FullName))
                {
                    IgnoreMissingMigrations.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(IgnoreIgnoredMigrations.FullName))
                {
                    IgnoreIgnoredMigrations.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(IgnorePendingMigrations.FullName))
                {
                    IgnorePendingMigrations.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(IgnoreFutureMigrations.FullName))
                {
                    IgnoreFutureMigrations.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(Mixed.FullName))
                {
                    Mixed.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(Group.FullName))
                {
                    Group.Value = ReadValue<bool?>(line);
                } else if(line.StartsWith(InstalledBy.FullName))
                {
                    InstalledBy.Value = ReadValue<string>(line);
                } else if(line.StartsWith(ErrorOverrides.FullName))
                {
                    ErrorOverrides.Value = ReadValue<string>(line);
                } else if(line.StartsWith(DryRunOutput.FullName))
                {
                    DryRunOutput.Value = ReadValue<string>(line);
                } else if(line.StartsWith(OracleSqlplus.FullName))
                {
                    OracleSqlplus.Value = ReadValue<string>(line);
                } else if(line.StartsWith(Encoding.FullName))
                {
                    Encoding.Value = ReadValue<string>(line);
                } else if(line.StartsWith(LicenseKey.FullName))
                {
                    LicenseKey.Value = ReadValue<string>(line);
                }
            }

            return this;
        }

        public void Save()
        {
            if(!IsInMemory)
            {
                Saver(ConfigurationFilePath, Regex.Replace(ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline));
            }
        }

        public override string ToString()
        {
            StringBuilder config = new StringBuilder();
            config.AppendLine(Url.Formatted());
            config.AppendLine(Driver.Formatted());
            config.AppendLine(User.Formatted());
            config.AppendLine(Password.Formatted());
            config.AppendLine(ConnectRetries.Formatted());
            config.AppendLine(InitSql.Formatted());
            config.AppendLine(Schemas.Formatted());
            config.AppendLine(Table.Formatted());
            config.AppendLine(Locations.Formatted());
            config.AppendLine(Resolvers.Formatted());
            config.AppendLine(SkipDefaultResolvers.Formatted());
            config.AppendLine(JarDirs.Formatted());
            config.AppendLine(SqlMigrationPrefix.Formatted());
            config.AppendLine(UndoSqlMigrationPrefix.Formatted());
            config.AppendLine(RepeatableSqlMigrationPrefix.Formatted());
            config.AppendLine(SqlMigrationSeparator.Formatted());
            config.AppendLine(SqlMigrationSuffixes.Formatted());
            config.AppendLine(Stream.Formatted());
            config.AppendLine(Batch.Formatted());
            config.AppendLine(PlaceholderReplacement.Formatted());
            config.AppendLine(Placeholders.Formatted());
            config.AppendLine(PlaceholderPrefix.Formatted());
            config.AppendLine(PlaceholderSuffix.Formatted());
            config.AppendLine(Target.Formatted());
            config.AppendLine(ValidateOnMigrate.Formatted());
            config.AppendLine(CleanOnValidationError.Formatted());
            config.AppendLine(CleanDisabled.Formatted());
            config.AppendLine(BaselineVersion.Formatted());
            config.AppendLine(BaselineDescription.Formatted());
            config.AppendLine(BaselineOnMigrate.Formatted());
            config.AppendLine(OutOfOrder.Formatted());
            config.AppendLine(Callbacks.Formatted());
            config.AppendLine(SkipDefaultCallbacks.Formatted());
            config.AppendLine(IgnoreMissingMigrations.Formatted());
            config.AppendLine(IgnoreIgnoredMigrations.Formatted());
            config.AppendLine(IgnorePendingMigrations.Formatted());
            config.AppendLine(IgnoreFutureMigrations.Formatted());
            config.AppendLine(Mixed.Formatted());
            config.AppendLine(Group.Formatted());
            config.AppendLine(InstalledBy.Formatted());
            config.AppendLine(ErrorOverrides.Formatted());
            config.AppendLine(DryRunOutput.Formatted());
            config.AppendLine(OracleSqlplus.Formatted());
            config.AppendLine(Encoding.Formatted());
            config.AppendLine(LicenseKey.Formatted());

            return config.ToString().Trim();
        }
    }
}
