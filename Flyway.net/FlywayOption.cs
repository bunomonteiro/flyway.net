using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyway.net
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1012:Abstract types should not have constructors", Justification = "<Pending>")]
    public abstract class FlywayOption<T>
    {
        public virtual T Value { get; set; }
        public Prefix Prefix { get; private set; }
        public string Name { get; private set; }
        public string FullName { get { return $"{this.Prefix}{this.Name}"; } }
        public bool Required { get; private set; }
        public bool IsProFeature { get; private set; }

        public FlywayOption(string name, bool required = false, string prefix = "-", bool isProFeature = false)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
            this.Required = required;
            this.Prefix = prefix;
            this.IsProFeature = isProFeature;
        }
        public virtual string Formatted() => String.IsNullOrWhiteSpace(this.ToString()) ? String.Empty : $"{this.FullName}={this}";

        public override string ToString()
        {
            if(!object.Equals(default(T), Value))
            {
                var tType = typeof(T);
                if(tType == typeof(bool?)) // boolean
                {
                    return Convert.ToString(this.Value).ToLower();
                }
                
                return Convert.ToString(this.Value).Trim();
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

        public FlywayListOption(string name , bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }

        public override string Formatted()
        {
            return !object.Equals(default(List<T>), Value) && Value.Any()
                ? $"{this.FullName}={String.Join(",", this.Value)}"
                : String.Empty;
        }

        public override string ToString()
        {
            return !object.Equals(default(List<T>), Value) && Value.Any()
                ? $"{this.Name}={String.Join(",", this.Value)}"
                : String.Empty;
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

        public FlywayDictionaryOption(string name , bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }

        public override string Formatted() => String.Join("\r\n", this.Values(true)).Trim();
        public override string ToString() => String.Join("\r\n", this.Values()).Trim();

        private string[] Values(bool fullname = false)
        {
            if(!object.Equals(default(Dictionary<TKey, TValue>), Value))
            {
                return this.Value.Select(item => $"{(fullname ? this.FullName : this.Name)}.{item.Key}={item.Value}").ToArray();
            } else
            {
                return Array.Empty<string>();
            }
        }
    }

    public class FlywayUrlOption : FlywayOption<string>
    {
        public FlywayUrlOption(string @value) : base("url", true) { this.Value = @value; }
        public FlywayUrlOption(string name = "url", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayDriverOption : FlywayOption<string>
    {
        public FlywayDriverOption(string @value) : base("driver") { this.Value = @value; }
        public FlywayDriverOption(string name = "driver", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayUserOption : FlywayOption<string>
    {
        public FlywayUserOption(string @value) : base("user") { this.Value = @value; }
        public FlywayUserOption(string name = "user", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPasswordOption : FlywayOption<string>
    {
        public FlywayPasswordOption(string @value) : base("password") { this.Value = @value; }
        public FlywayPasswordOption(string name = "password", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayConnectRetriesOption : FlywayOption<ushort?>
    {
        public FlywayConnectRetriesOption(ushort? @value) : base("connectRetries") { this.Value = @value; }
        public FlywayConnectRetriesOption(string name = "connectRetries", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayInitSqlOption : FlywayOption<string>
    {
        public FlywayInitSqlOption(string @value) : base("initSql") { this.Value = @value; }
        public FlywayInitSqlOption(string name = "initSql", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySchemasOption : FlywayListOption<string>
    {
        public FlywaySchemasOption(List<string> @value) : base("schemas") { this.Value = @value; }
        public FlywaySchemasOption(string name = "schemas", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayTableOption : FlywayOption<string>
    {
        public FlywayTableOption(string @value) : base("table") { this.Value = @value; }
        public FlywayTableOption(string name = "table", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayLocationsOption : FlywayOption<string>
    {
        public FlywayLocationsOption(string @value) : base("locations") { this.Value = @value; }
        public FlywayLocationsOption(string name = "locations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayJarDirsOption : FlywayOption<string>
    {
        public FlywayJarDirsOption(string @value) : base("jarDirs") { this.Value = @value; }
        public FlywayJarDirsOption(string name = "jarDirs", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywaySqlMigrationPrefixOption(string @value) : base("sqlMigrationPrefix") { this.Value = @value; }
        public FlywaySqlMigrationPrefixOption(string name = "sqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayUndoSqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywayUndoSqlMigrationPrefixOption(string @value) : base("undoSqlMigrationPrefix", isProFeature: true) { this.Value = @value; }
        public FlywayUndoSqlMigrationPrefixOption(string name = "undoSqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayRepeatableSqlMigrationPrefixOption : FlywayOption<string>
    {
        public FlywayRepeatableSqlMigrationPrefixOption(string @value) : base("repeatableSqlMigrationPrefix") { this.Value = @value; }
        public FlywayRepeatableSqlMigrationPrefixOption(string name = "repeatableSqlMigrationPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationSeparatorOption : FlywayOption<string>
    {
        public FlywaySqlMigrationSeparatorOption(string @value) : base("sqlMigrationSeparator") { this.Value = @value; }
        public FlywaySqlMigrationSeparatorOption(string name = "sqlMigrationSeparator", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySqlMigrationSuffixesOption : FlywayOption<string>
    {
        public FlywaySqlMigrationSuffixesOption(string @value) : base("sqlMigrationSuffixes") { this.Value = @value; }
        public FlywaySqlMigrationSuffixesOption(string name = "sqlMigrationSuffixes", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayStreamOption : FlywayOption<bool?>
    {
        public FlywayStreamOption(bool? @value) : base("stream", isProFeature: true) { this.Value = @value; }
        public FlywayStreamOption(string name = "stream", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBatchOption : FlywayOption<bool?>
    {
        public FlywayBatchOption(bool? @value) : base("batch", isProFeature: true) { this.Value = @value; }
        public FlywayBatchOption(string name = "batch", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayMixedOption : FlywayOption<bool?>
    {
        public FlywayMixedOption(bool? @value) : base("mixed") { this.Value = @value; }
        public FlywayMixedOption(string name = "mixed", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayGroupOption : FlywayOption<bool?>
    {
        public FlywayGroupOption(bool? @value) : base("group") { this.Value = @value; }
        public FlywayGroupOption(string name = "group", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayEncodingOption : FlywayOption<string>
    {
        public FlywayEncodingOption(string @value) : base("encoding") { this.Value = @value; }
        public FlywayEncodingOption(string name = "encoding", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholderReplacementOption : FlywayOption<bool?>
    {
        public FlywayPlaceholderReplacementOption(bool? @value) : base("placeholderReplacement") { this.Value = @value; }
        public FlywayPlaceholderReplacementOption(string name = "placeholderReplacement", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholdersOption : FlywayDictionaryOption<string, string>
    {
        public FlywayPlaceholdersOption(Dictionary<string, string> @value) : base("placeholders") { this.Value = @value; }
        public FlywayPlaceholdersOption(string name = "placeholders", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { this.Value = new Dictionary<string, string>(); }
    }
    public class FlywayPlaceholderPrefixOption : FlywayOption<string>
    {
        public FlywayPlaceholderPrefixOption(string @value) : base("placeholderPrefix") { this.Value = @value; }
        public FlywayPlaceholderPrefixOption(string name = "placeholderPrefix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayPlaceholderSuffixOption : FlywayOption<string>
    {
        public FlywayPlaceholderSuffixOption(string @value) : base("placeholderSuffix") { this.Value = @value; }
        public FlywayPlaceholderSuffixOption(string name = "placeholderSuffix", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayResolversOption : FlywayOption<string>
    {
        public FlywayResolversOption(string @value) : base("resolvers") { this.Value = @value; }
        public FlywayResolversOption(string name = "resolvers", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywaySkipDefaultResolversOption : FlywayOption<bool?>
    {
        public FlywaySkipDefaultResolversOption(bool? @value) : base("skipDefaultResolvers") { this.Value = @value; }
        public FlywaySkipDefaultResolversOption(string name = "skipDefaultResolvers", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCallbacksOption : FlywayListOption<string>
    {
        public FlywayCallbacksOption(List<string> @value) : base("callbacks") { this.Value = @value; }
        public FlywayCallbacksOption(string name = "callbacks", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { this.Value = new List<string>(); }
    }
    public class FlywaySkipDefaultCallbacksOption : FlywayOption<bool?>
    {
        public FlywaySkipDefaultCallbacksOption(bool? @value) : base("skipDefaultCallbacks") { this.Value = @value; }
        public FlywaySkipDefaultCallbacksOption(string name = "skipDefaultCallbacks", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayTargetOption : FlywayOption<string>
    {
        public FlywayTargetOption(string @value) : base("target") { this.Value = @value; }
        public FlywayTargetOption(string name = "target", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayOutOfOrderOption : FlywayOption<bool?>
    {
        public FlywayOutOfOrderOption(bool? @value) : base("outOfOrder") { this.Value = @value; }
        public FlywayOutOfOrderOption(string name = "outOfOrder", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayValidateOnMigrateOption : FlywayOption<bool?>
    {
        public FlywayValidateOnMigrateOption(bool? @value) : base("validateOnMigrate") { this.Value = @value; }
        public FlywayValidateOnMigrateOption(string name = "validateOnMigrate", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCleanOnValidationErrorOption : FlywayOption<bool?>
    {
        public FlywayCleanOnValidationErrorOption(bool? @value) : base("cleanOnValidationError") { this.Value = @value; }
        public FlywayCleanOnValidationErrorOption(string name = "cleanOnValidationError", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreMissingMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreMissingMigrationsOption(bool? @value) : base("ignoreMissingMigrations") { this.Value = @value; }
        public FlywayIgnoreMissingMigrationsOption(string name = "ignoreMissingMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreIgnoredMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreIgnoredMigrationsOption(bool? @value) : base("ignoreIgnoredMigrations") { this.Value = @value; }
        public FlywayIgnoreIgnoredMigrationsOption(string name = "ignoreIgnoredMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnorePendingMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnorePendingMigrationsOption(bool? @value) : base("ignorePendingMigrations") { this.Value = @value; }
        public FlywayIgnorePendingMigrationsOption(string name = "ignorePendingMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayIgnoreFutureMigrationsOption : FlywayOption<bool?>
    {
        public FlywayIgnoreFutureMigrationsOption(bool? @value) : base("ignoreFutureMigrations") { this.Value = @value; }
        public FlywayIgnoreFutureMigrationsOption(string name = "ignoreFutureMigrations", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayCleanDisabledOption : FlywayOption<bool?>
    {
        public FlywayCleanDisabledOption(bool? @value) : base("cleanDisabled") { this.Value = @value; }
        public FlywayCleanDisabledOption(string name = "cleanDisabled", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineOnMigrateOption : FlywayOption<bool?>
    {
        public FlywayBaselineOnMigrateOption(bool? @value) : base("baselineOnMigrate") { this.Value = @value; }
        public FlywayBaselineOnMigrateOption(string name = "baselineOnMigrate", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineVersionOption : FlywayOption<uint?>
    {
        public FlywayBaselineVersionOption(uint? @value) : base("baselineVersion") { this.Value = @value; }
        public FlywayBaselineVersionOption(string name = "baselineVersion", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayBaselineDescriptionOption : FlywayOption<string>
    {
        public FlywayBaselineDescriptionOption(string @value) : base("baselineDescription") { this.Value = @value; }
        public FlywayBaselineDescriptionOption(string name = "baselineDescription", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayInstalledByOption : FlywayOption<string>
    {
        public FlywayInstalledByOption(string @value) : base("installedBy") { this.Value = @value; }
        public FlywayInstalledByOption(string name = "installedBy", bool required = false, string prefix = "-", bool isProFeature = false)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayErrorOverridesOption : FlywayOption<string>
    {
        public FlywayErrorOverridesOption(string @value) : base("errorOverrides", isProFeature: true) { this.Value = @value; }
        public FlywayErrorOverridesOption(string name = "errorOverrides", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayDryRunOutputOption : FlywayOption<string>
    {
        public FlywayDryRunOutputOption(string @value) : base("dryRunOutput", isProFeature: true) { this.Value = @value; }
        public FlywayDryRunOutputOption(string name = "dryRunOutput", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayOracleSqlplusOption : FlywayOption<string>
    {
        public FlywayOracleSqlplusOption(string @value) : base("oracle.sqlplus", isProFeature: true) { this.Value = @value; }
        public FlywayOracleSqlplusOption(string name = "oracle.sqlplus", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
    public class FlywayLicenseKeyOption : FlywayOption<string>
    {
        public FlywayLicenseKeyOption(string @value) : base("licenseKey", isProFeature: true) { this.Value = @value; }
        public FlywayLicenseKeyOption(string name = "licenseKey", bool required = false, string prefix = "-", bool isProFeature = true)
            : base(name, required, prefix, isProFeature) { }
    }
}
