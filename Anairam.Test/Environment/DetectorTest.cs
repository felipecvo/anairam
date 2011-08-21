namespace Anairam.Test {
    using NUnit.Framework;

    [TestFixture]
    public class DetectorTest {
        [Test]
        public void ShouldSetSectionName() {
            Detector.SetSectionName("environmentDetector1");
            Detector.Current.Should().Eq("dev");
        }

        [Test]
        public void ShouldReturnDefaultEnvWhenHasNoRules() {
            Detector.SetSectionName("environmentDetector");
            Detector.Current.Should().Eq("development");
        }

        [Test]
        public void ShouldReturnDefaultWhenHasMultipleMatches() {
            Detector.SetSectionName("environmentDetector3");
            Detector.Current.Should().Eq("local");
        }
    }
}