using System;
using Xunit;

namespace Flyway.net.Tests
{
    public class FlywayConfigurationTest
    {
        private const string TheUser = "the_user";
        private const string ThePassword = "the_password";

        private string _configurationContent;
        private readonly FlywayConfiguration _configuration;

        public FlywayConfigurationTest()
        {
            this._configuration = new FlywayConfiguration(this.Saver, this.Loader);
        }

        [Fact]
        public void SaveConfigurationTest()
        {
            this._configuration.User.Value = TheUser;
            this._configuration.Password.Value = ThePassword;
            this._configuration.Save();

            Assert.NotNull(this._configurationContent);
        }

        [Fact]
        public void LoadConfigurationTest()
        {
            SaveConfigurationTest();

            var configuration = this._configuration.Load();

            Assert.Equal(TheUser, configuration.User.Value);
            Assert.Equal(ThePassword, configuration.Password.Value);
        }

        private void Saver(string path, string configuration)
        {
            this._configurationContent = configuration;
        }

        private string[] Loader(string path)
        {
            return _configurationContent.Split(new string[]{ "\r\n" }, StringSplitOptions.None);
        }
    }
}
