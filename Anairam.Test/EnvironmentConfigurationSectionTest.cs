namespace Anairam.Test {
    using NUnit.Framework;
    using System.Configuration;

    [TestFixture]
    public class EnvironmentConfigurationSectionTest {
        [SetUp]
        public void Before() {
            Detector.SetSectionName("environmentDetector");
        }

        [Test]
        public void ShouldGetConfigurationForDevEnvironment() {
            var section = (DatabaseConfigurationSection)ConfigurationManager.GetSection("database");
            section.ShouldNot().BeNull();
            section.Adapter.Should().Eq("mysql");
            section.Server.Should().Eq("localhost");
            section.Database.Should().Eq("boycott");
            section.User.Should().Eq("root");
            section.Password.Should().Eq("root");
        }

        [Test]
        public void ShouldGetConfigurationForDevEnvironmentFromExternalFile() {
            var section = (DatabaseConfigurationSection)ConfigurationManager.GetSection("databaseEx");
            section.ShouldNot().BeNull();
            section.Adapter.Should().Eq("sqlserver");
            section.Server.Should().Eq("localhost");
            section.Database.Should().Eq("boycott");
            section.User.Should().Eq("sa");
            section.Password.Should().Eq("SysAdmin");
        }
    }

    class DatabaseConfigurationSection : EnvironmentConfigurationSection {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Adapter { get; set; }
    }
}