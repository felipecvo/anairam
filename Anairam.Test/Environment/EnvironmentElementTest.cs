namespace Anairam.Test.Environment {
    using NUnit.Framework;
    using Anairam.Environment;

    [TestFixture]
    public class EnvironmentElementTest {
        [Test]
        public void ShouldCreateWithName() {
            var element = new EnvironmentElement("development");

            element.Name.Should().Eq("development");
        }

        [Test]
        public void ShouldMatchEvaluate() {
            var element = new EnvironmentElement("development");

            element.Name.Should().Eq("development");

            element.AddMatchers("machineName", System.Environment.MachineName);
            element.AddMatchers("processorCount", System.Environment.ProcessorCount.ToString());
            element.AddMatchers("userName", System.Environment.UserName);

            element.Evaluate().Should().Eq(true);
        }

        [Test]
        public void ShouldNotMatchEvaluate() {
            var element = new EnvironmentElement("test");

            element.Name.Should().Eq("test");

            element.AddMatchers("machineName", "non-existent");
            element.AddMatchers("processorCount", "3");
            element.AddMatchers("userName", "none");

            element.Evaluate().Should().Eq(false);
        }
    }
}
