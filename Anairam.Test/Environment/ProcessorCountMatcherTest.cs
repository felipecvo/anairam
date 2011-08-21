namespace Anairam.Test.Environment {
    using NUnit.Framework;
    using Anairam.Environment;

    [TestFixture]
    public class ProcessorCountMatcherTest {
        [Test]
        public void ShouldMatchProcessorCount() {
            var matcher = new ProcessorCountMatcher(System.Environment.ProcessorCount.ToString()) as Matcher;

            matcher.IsMatch().Should().BeTrue();
        }

        [Test]
        public void ShouldNotMatchProcessorCount() {
            var matcher = new ProcessorCountMatcher("3") as Matcher;

            matcher.IsMatch().Should().BeFalse();
        }
    }
}
