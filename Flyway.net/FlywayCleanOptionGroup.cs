﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyway.net
{
    /// <summary>
    /// https://flywaydb.org/documentation/commandline/clean
    /// </summary>
    public class FlywayCleanOptionGroup : FlywayOptionGroup
    {
        public FlywayDriverOption Driver { get; set; }
        public FlywayUserOption User { get; set; }
        public FlywayPasswordOption Password { get; set; }
        public FlywayConnectRetriesOption ConnectRetries { get; set; }
        public FlywayInitSqlOption InitSql { get; set; }
        public FlywaySchemasOption Schemas { get; set; }
        public FlywayJarDirsOption JarDirs { get; set; }
        public FlywayCallbacksOption Callbacks { get; set; }
        public FlywaySkipDefaultCallbacksOption SkipDefaultCallbacks { get; set; }
        public FlywayCleanDisabledOption CleanDisabled { get; set; }
        public FlywayLicenseKeyOption LicenseKey { get; set; }

        public FlywayCleanOptionGroup()
        {
            this.Url = new FlywayUrlOption();
            this.Driver = new FlywayDriverOption();
            this.User = new FlywayUserOption();
            this.Password = new FlywayPasswordOption();
            this.ConnectRetries = new FlywayConnectRetriesOption();
            this.InitSql = new FlywayInitSqlOption();
            this.Schemas = new FlywaySchemasOption();
            this.JarDirs = new FlywayJarDirsOption();
            this.Callbacks = new FlywayCallbacksOption();
            this.SkipDefaultCallbacks = new FlywaySkipDefaultCallbacksOption();
            this.CleanDisabled = new FlywayCleanDisabledOption();
            this.LicenseKey = new FlywayLicenseKeyOption();
        }

        public override string ToArgs()
        {
            var options = new List<string>
            {
                Url.Formatted(),
                Driver.Formatted(),
                User.Formatted(),
                Password.Formatted(),
                ConnectRetries.Formatted(),
                InitSql.Formatted(),
                Schemas.Formatted(),
                JarDirs.Formatted(),
                Callbacks.Formatted(),
                SkipDefaultCallbacks.Formatted(),
                CleanDisabled.Formatted(),
                LicenseKey.Formatted()
            };

            return String.Join(" ", options.Where(v => !String.IsNullOrWhiteSpace(v)).Select(v => v.Replace("\r\n", " ").Trim()));
        }

        public static implicit operator FlywayCleanOptionGroup(FlywayConfiguration configuration)
        {
            var options = new FlywayCleanOptionGroup();
            options.Url.Value = configuration.Url.Value;
            options.Driver.Value = configuration.Driver.Value;
            options.User.Value = configuration.User.Value;
            options.Password.Value = configuration.Password.Value;
            options.ConnectRetries.Value = configuration.ConnectRetries.Value;
            options.InitSql.Value = configuration.InitSql.Value;
            options.Schemas.Value = configuration.Schemas.Value;
            options.JarDirs.Value = configuration.JarDirs.Value;
            options.Callbacks.Value = configuration.Callbacks.Value;
            options.SkipDefaultCallbacks.Value = configuration.SkipDefaultCallbacks.Value;
            options.CleanDisabled.Value = configuration.CleanDisabled.Value;
            options.LicenseKey.Value = configuration.LicenseKey.Value;

            return options;
        }
    }
}
