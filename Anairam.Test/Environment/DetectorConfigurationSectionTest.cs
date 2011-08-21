namespace Anairam.Test.Environment {
    using NUnit.Framework;
    using System.Configuration;
    using System.Web.Configuration;
    using Anairam.Environment;

    [TestFixture]
    public class DetectorConfigurationSectionTest {
        [Test]
        public void ShouldGetDataFromAppConfig() {
            var detector = (DetectorConfigurationSection)ConfigurationManager.GetSection("environmentDetector1");
            detector.ShouldNot().BeNull();
            detector.Default.Should().Eq("dev");
        }

        [Test]
        public void ShouldGetMatchersFromConfig() {
            var detector = (DetectorConfigurationSection)ConfigurationManager.GetSection("environmentDetector2");
            detector.ShouldNot().BeNull();
            detector.Default.Should().Eq("test");
            detector.Environments.Count.Should().Eq(3);

            detector.Environments[0].Name.Should().Eq("development");
            detector.Environments[1].Name.Should().Eq("test");
            detector.Environments[2].Name.Should().Eq("production");

            detector.Environments[0].Matchers.Count.Should().Eq(2);
            detector.Environments[1].Matchers.Count.Should().Eq(3);
            detector.Environments[2].Matchers.Count.Should().Eq(2);

            detector.Environments[0].Matchers[0].Should().BeA(typeof(MachineNameMatcher));
            detector.Environments[0].Matchers[0].Value.Should().Eq("note-anairam");
            detector.Environments[0].Matchers[1].Should().BeA(typeof(ProcessorCountMatcher));
            detector.Environments[0].Matchers[1].Value.Should().Eq("2");

            detector.Environments[1].Matchers[0].Should().BeA(typeof(MachineNameMatcher));
            detector.Environments[1].Matchers[0].Value.Should().Eq("v-anairam-test");
            detector.Environments[1].Matchers[1].Should().BeA(typeof(ProcessorCountMatcher));
            detector.Environments[1].Matchers[1].Value.Should().Eq("8");
            detector.Environments[1].Matchers[2].Should().BeA(typeof(UserNameMatcher));
            detector.Environments[1].Matchers[2].Value.Should().Eq("I_USR_ANAIRAM");

            detector.Environments[2].Matchers[0].Should().BeA(typeof(ProcessorCountMatcher));
            detector.Environments[2].Matchers[0].Value.Should().Eq("16");
            detector.Environments[2].Matchers[1].Should().BeA(typeof(UserNameMatcher));
            detector.Environments[2].Matchers[1].Value.Should().Eq("I_USR_ANAIRAM");
        }
    }
}
