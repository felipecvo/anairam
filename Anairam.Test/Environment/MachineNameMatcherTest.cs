namespace Anairam.Test.Environment {
    using NUnit.Framework;
    using Anairam.Environment;

    [TestFixture]
    public class MachineNameMatcherTest {
        [Test]
        public void ShouldMatchMachineName() {
            var matcher = new MachineNameMatcher(System.Environment.MachineName) as Matcher;

            matcher.IsMatch().Should().BeTrue();
        }

        [Test]
        public void ShouldNotMatchMachineName() {
            var matcher = new MachineNameMatcher("notamachine") as Matcher;

            matcher.IsMatch().Should().BeFalse();
        }
    }
}
