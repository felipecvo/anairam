namespace Anairam.Test {
    using NUnit.Framework;
    using System.Configuration;

    [TestFixture]
    public class EnvironmentConfigurationSectionTest {
        [Test]
        public void ShouldGetConfigurationForDevEnvironment() {
            var section = (DatabaseConfigurationSection)ConfigurationManager.GetSection("database");
            section.ShouldNot().BeNull();
            section.Driver.Should().Eq("MySql");
            section.Host.Should().Eq("localhost");
            section.Database.Should().Eq("boycott");
            section.User.Should().Eq("root");
            section.Password.Should().Eq("root");
        }
    }

    class DatabaseConfigurationSection : EnvironmentConfigurationSection {
        public string Host { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Driver { get; set; }
    }
}