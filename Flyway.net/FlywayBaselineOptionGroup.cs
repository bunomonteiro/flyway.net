using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyway.net
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/baseline
    /// </summary>
    public class FlywayBaselineOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayTableOption Table { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayBaselineVersionOption BaselineVersion { get; set; }
        public FlywayBaselineDescriptionOption BaselineDescription { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayBaselineOptionGroup()
        {
            this.Url = new FlywayUrlOption();
            this.Driver = new FlywayDriverOption();
            this.User = new FlywayUserOption();
            this.Password = new FlywayPasswordOption();
            this.ConnectRetries = new FlywayConnectRetriesOption();
            this.InitSql = new FlywayInitSqlOption();
            this.Schemas = new FlywaySchemasOption();
            this.Table = new FlywayTableOption();
            this.JarDirs = new FlywayJarDirsOption();
            this.Callbacks = new FlywayCallbacksOption();
            this.SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            this.BaselineVersion = new FlywayBaselineVersionOption();
            this.BaselineDescription = new FlywayBaselineDescriptionOption();
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
            options.Add(JarDirs.Formatted());
            options.Add(Callbacks.Formatted());
            options.Add(SkipDefaultCallbacks.Formatted());
            options.Add(BaselineVersion.Formatted());
            options.Add(BaselineDescription.Formatted());
            options.Add(LicenseKey.Formatted());

            return String.Join(" ", options.Where(v => !String.IsNullOrWhiteSpace(v)).Select(v => v.Trim()));
        }

        public static implicit operator FlywayBaselineOptionGroup(FlywayConfiguration configuration)
        {
            var options = new FlywayBaselineOptionGroup();
            options.BaselineDescription.Value = configuration.BaselineDescription.Value;
            options.BaselineVersion.Value = configuration.BaselineVersion.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;
            options.Password.Value = configuration.Password.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.Table.Value = configuration.Table.Value;
            options.Url.Value = configuration.Url.Value;
            options.User.Value = configuration.User.Value;

            return options;
        }
    }
}
