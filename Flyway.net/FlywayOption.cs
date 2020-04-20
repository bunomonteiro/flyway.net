using System;
using System.Collections.Generic;
using System.Linq;

using Flyway.net.ValueObjects;

namespace Flyway.net
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1012:Abstract types should not have constructors", Justification = "<Pending>")]
    public abstract class FlywayOption<T>
    {
        public virtual T Value { get; set; }
        public Prefix Prefix { get; private set; }
        public string Name { get; private set; }
        public string FullName => $"{Prefix}{Name}";
        public bool Required { get; private set; }
        public bool IsProFeature { get; private set; }

        public FlywayOption(string name, bool required = false, string prefix = "-", bool isProFeature = false)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Required = required;
            Prefix = prefix;
            IsProFeature = isProFeature;
        }
        public virtual string Formatted()
        {
            return string.IsNullOrWhiteSpace(ToString()) ? string.Empty : $"{FullName}={this}";
        }

        public override string ToString()
        {
            if(!object.Equals(default(T), Value))
            {
                Type tType = typeof(T);
                if(tType == typeof(bool?)) // boolean
                {
                    return Convert.ToString(Value).ToLower();
                }

                return Convert.ToString(Value).Trim();
            }

            return string.Empty;
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1012:Abstract types should not have constructors", Justification = "<Pending>")]
    public abstract class FlywayListOption<T> : FlywayOption<List<T>>
    {
        public override List<T> Value
        {
            get => base.Value = (base.Value ?? new List<T>());
            set => base.Value = value;
        }

        public FlywayListOption(string name, bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }

        public override string Formatted()
        {
            return !object.Equals(default(List<T>), Value) && Value.Any()
                ? $"{FullName}={string.Join(",", Value)}"
                : string.Empty;
        }

        public override string ToString()
        {
            return !object.Equals(default(List<T>), Value) && Value.Any()
                ? $"{Name}={string.Join(",", Value)}"
                : string.Empty;
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1012:Abstract types should not have constructors", Justification = "<Pending>")]
    public abstract class FlywayDictionaryOption<TKey, TValue> : FlywayOption<Dictionary<TKey, TValue>>
    {
        public override Dictionary<TKey, TValue> Value
        {
            get => base.Value = (base.Value ?? new Dictionary<TKey, TValue>());
            set => base.Value = value;
        }

        public FlywayDictionaryOption(string name, bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }

        public override string Formatted()
        {
            return string.Join("\r\n", Values(true)).Trim();
        }

        public override string ToString()
        {
            return string.Join("\r\n", Values()).Trim();
        }

        private string[] Values(bool fullname = false)
        {
            if(!object.Equals(default(Dictionary<TKey, TValue>), Value))
            {
                return Value.Select(item => $"{(fullname ? FullName : Name)}.{item.Key}={item.Value}").ToArray();
            } else
            {
                return Array.Empty<string>();
            }
        }
    }

    public class FlywayUrlOption : FlywayOption<string>
    {
        public FlywayUrlOption(string @value) : base("url", true) { Value = @value; }
        public FlywayUrlOption(string name = "url", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayDriverOption : FlywayOption<string>
    {
        public FlywayDriverOption(string @value) : base("driver") { Value = @value; }
        public FlywayDriverOption(string name = "driver", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayUserOption : FlywayOption<string>
    {
        public FlywayUserOption(string @value) : base("user") { Value = @value; }
        public FlywayUserOption(string name = "user", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPasswordOption : FlywayOption<string>
    {
        public FlywayPasswordOption(string @value) : base("password") { Value = @value; }
        public FlywayPasswordOption(string name = "password", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayConnectRetriesOption : FlywayOption<ushort?>
    {
        public FlywayConnectRetriesOption(ushort? @value) : base("connectRetries") { Value = @value; }
        public FlywayConnectRetriesOption(string name = "connectRetries", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayInitSqlOption : FlywayOption<string>
    {
        public FlywayInitSqlOption(string @value) : base("initSql") { Value = @value; }
        public FlywayInitSqlOption(string name = "initSql", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySchemasOption : FlywayListOption<string>
    {
        public FlywaySchemasOption(List<string> @value) : base("schemas") { Value = @value; }
        public FlywaySchemasOption(string name = "schemas", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayTableOption : FlywayOption<string>
    {
        public FlywayTableOption(string @value) : base("table") { Value = @value; }
        public FlywayTableOption(string name = "table", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayLocationsOption : FlywayListOption<string>
    {
        public FlywayLocationsOption(List<string> @value) : base("locations") { Value = @value; }
        public FlywayLocationsOption(string name = "locations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayJarDirsOption : FlywayOption<string>
    {
        public FlywayJarDirsOption(string @value) : base("jarDirs") { Value = @value; }
        public FlywayJarDirsOption(string name = "jarDirs", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywaySqlMigrationPrefixOption(string @value) : base("sqlMigrationPrefix") { Value = @value; }
        public FlywaySqlMigrationPrefixOption(string name = "sqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayUndoSqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywayUndoSqlMigrationPrefixOption(string @value) : base("undoSqlMigrationPrefix", isProFeature: true) { Value = @value; }
        public FlywayUndoSqlMigrationPrefixOption(string name = "undoSqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayRepeatableSqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywayRepeatableSqlMigrationPrefixOption(string @value) : base("repeatableSqlMigrationPrefix") { Value = @value; }
        public FlywayRepeatableSqlMigrationPrefixOption(string name = "repeatableSqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationSeparatorOption : FlywayOption<string>
    {
        public FlywaySqlMigrationSeparatorOption(string @value) : base("sqlMigrationSeparator") { Value = @value; }
        public FlywaySqlMigrationSeparatorOption(string name = "sqlMigrationSeparator", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationSuffixesOption : FlywayOption<string>
    {
        public FlywaySqlMigrationSuffixesOption(string @value) : base("sqlMigrationSuffixes") { Value = @value; }
        public FlywaySqlMigrationSuffixesOption(string name = "sqlMigrationSuffixes", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayStreamOption : FlywayOption<bool?>
    {
        public FlywayStreamOption(bool? @value) : base("stream", isProFeature: true) { Value = @value; }
        public FlywayStreamOption(string name = "stream", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBatchOption : FlywayOption<bool?>
    {
        public FlywayBatchOption(bool? @value) : base("batch", isProFeature: true) { Value = @value; }
        public FlywayBatchOption(string name = "batch", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayMixedOption : FlywayOption<bool?>
    {
        public FlywayMixedOption(bool? @value) : base("mixed") { Value = @value; }
        public FlywayMixedOption(string name = "mixed", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayGroupOption : FlywayOption<bool?>
    {
        public FlywayGroupOption(bool? @value) : base("group") { Value = @value; }
        public FlywayGroupOption(string name = "group", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayEncodingOption : FlywayOption<string>
    {
        public FlywayEncodingOption(string @value) : base("encoding") { Value = @value; }
        public FlywayEncodingOption(string name = "encoding", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholderReplacementOption : FlywayOption<bool?>
    {
        public FlywayPlaceholderReplacementOption(bool? @value) : base("placeholderReplacement") { Value = @value; }
        public FlywayPlaceholderReplacementOption(string name = "placeholderReplacement", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholdersOption : FlywayDictionaryOption<string, string>
    {
        public FlywayPlaceholdersOption(Dictionary<string, string> @value) : base("placeholders") { Value = @value; }
        public FlywayPlaceholdersOption(string name = "placeholders", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { Value = new Dictionary<string, string>(); }
    }
    public class FlywayPlaceholderPrefixOption : FlywayOption<string>
    {
        public FlywayPlaceholderPrefixOption(string @value) : base("placeholderPrefix") { Value = @value; }
        public FlywayPlaceholderPrefixOption(string name = "placeholderPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholderSuffixOption : FlywayOption<string>
    {
        public FlywayPlaceholderSuffixOption(string @value) : base("placeholderSuffix") { Value = @value; }
        public FlywayPlaceholderSuffixOption(string name = "placeholderSuffix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayResolversOption : FlywayOption<string>
    {
        public FlywayResolversOption(string @value) : base("resolvers") { Value = @value; }
        public FlywayResolversOption(string name = "resolvers", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySkipDefaultResolversOption : FlywayOption<bool?>
    {
        public FlywaySkipDefaultResolversOption(bool? @value) : base("skipDefaultResolvers") { Value = @value; }
        public FlywaySkipDefaultResolversOption(string name = "skipDefaultResolvers", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCallbacksOption : FlywayListOption<string>
    {
        public FlywayCallbacksOption(List<string> @value) : base("callbacks") { Value = @value; }
        public FlywayCallbacksOption(string name = "callbacks", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { Value = new List<string>(); }
    }
    public class FlywaySkipDefaultCallbacksOption : FlywayOption<bool?>
    {
        public FlywaySkipDefaultCallbacksOption(bool? @value) : base("skipDefaultCallbacks") { Value = @value; }
        public FlywaySkipDefaultCallbacksOption(string name = "skipDefaultCallbacks", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayTargetOption : FlywayOption<string>
    {
        public FlywayTargetOption(string @value) : base("target") { Value = @value; }
        public FlywayTargetOption(string name = "target", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayOutOfOrderOption : FlywayOption<bool?>
    {
        public FlywayOutOfOrderOption(bool? @value) : base("outOfOrder") { Value = @value; }
        public FlywayOutOfOrderOption(string name = "outOfOrder", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayValidateOnMigrateOption : FlywayOption<bool?>
    {
        public FlywayValidateOnMigrateOption(bool? @value) : base("validateOnMigrate") { Value = @value; }
        public FlywayValidateOnMigrateOption(string name = "validateOnMigrate", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCleanOnValidationErrorOption : FlywayOption<bool?>
    {
        public FlywayCleanOnValidationErrorOption(bool? @value) : base("cleanOnValidationError") { Value = @value; }
        public FlywayCleanOnValidationErrorOption(string name = "cleanOnValidationError", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreMissingMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreMissingMigrationsOption(bool? @value) : base("ignoreMissingMigrations") { Value = @value; }
        public FlywayIgnoreMissingMigrationsOption(string name = "ignoreMissingMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreIgnoredMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreIgnoredMigrationsOption(bool? @value) : base("ignoreIgnoredMigrations") { Value = @value; }
        public FlywayIgnoreIgnoredMigrationsOption(string name = "ignoreIgnoredMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnorePendingMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnorePendingMigrationsOption(bool? @value) : base("ignorePendingMigrations") { Value = @value; }
        public FlywayIgnorePendingMigrationsOption(string name = "ignorePendingMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreFutureMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreFutureMigrationsOption(bool? @value) : base("ignoreFutureMigrations") { Value = @value; }
        public FlywayIgnoreFutureMigrationsOption(string name = "ignoreFutureMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCleanDisabledOption : FlywayOption<bool?>
    {
        public FlywayCleanDisabledOption(bool? @value) : base("cleanDisabled") { Value = @value; }
        public FlywayCleanDisabledOption(string name = "cleanDisabled", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineOnMigrateOption : FlywayOption<bool?>
    {
        public FlywayBaselineOnMigrateOption(bool? @value) : base("baselineOnMigrate") { Value = @value; }
        public FlywayBaselineOnMigrateOption(string name = "baselineOnMigrate", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineVersionOption : FlywayOption<uint?>
    {
        public FlywayBaselineVersionOption(uint? @value) : base("baselineVersion") { Value = @value; }
        public FlywayBaselineVersionOption(string name = "baselineVersion", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineDescriptionOption : FlywayOption<string>
    {
        public FlywayBaselineDescriptionOption(string @value) : base("baselineDescription") { Value = @value; }
        public FlywayBaselineDescriptionOption(string name = "baselineDescription", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayInstalledByOption : FlywayOption<string>
    {
        public FlywayInstalledByOption(string @value) : base("installedBy") { Value = @value; }
        public FlywayInstalledByOption(string name = "installedBy", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayErrorOverridesOption : FlywayOption<string>
    {
        public FlywayErrorOverridesOption(string @value) : base("errorOverrides", isProFeature: true) { Value = @value; }
        public FlywayErrorOverridesOption(string name = "errorOverrides", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayDryRunOutputOption : FlywayOption<string>
    {
        public FlywayDryRunOutputOption(string @value) : base("dryRunOutput", isProFeature: true) { Value = @value; }
        public FlywayDryRunOutputOption(string name = "dryRunOutput", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayOracleSqlplusOption : FlywayOption<string>
    {
        public FlywayOracleSqlplusOption(string @value) : base("oracle.sqlplus", isProFeature: true) { Value = @value; }
        public FlywayOracleSqlplusOption(string name = "oracle.sqlplus", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayLicenseKeyOption : FlywayOption<string>
    {
        public FlywayLicenseKeyOption(string @value) : base("licenseKey", isProFeature: true) { Value = @value; }
        public FlywayLicenseKeyOption(string name = "licenseKey", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
}
