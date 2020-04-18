using System.Text;

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
            var options = new StringBuilder();

            if(Url != null)
                options.Append($" {Url.Formatted()}");
            if(Driver != null)
                options.Append($" {Driver.Formatted()}");
            if(User != null)
                options.Append($" {User.Formatted()}");
            if(Password != null)
                options.Append($" {Password.Formatted()}");
            if(ConnectRetries != null)
                options.Append($" {ConnectRetries.Formatted()}");
            if(InitSql != null)
                options.Append($" {InitSql.Formatted()}");
            if(Schemas != null)
                options.Append($" {Schemas.Formatted()}");
            if(Table != null)
                options.Append($" {Table.Formatted()}");
            if(JarDirs != null)
                options.Append($" {JarDirs.Formatted()}");
            if(Callbacks != null)
                options.Append($" {Callbacks.Formatted()}");
            if(SkipDefaultCallbacks != null)
                options.Append($" {SkipDefaultCallbacks.Formatted()}");
            if(BaselineVersion != null)
                options.Append($" {BaselineVersion.Formatted()}");
            if(BaselineDescription != null)
                options.Append($" {BaselineDescription.Formatted()}");
            if(LicenseKey != null)
                options.Append($" {LicenseKey.Formatted()}");

            return options.ToString().Trim();
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
