namespace Anairam.Test.Environment {
    using NUnit.Framework;
    using Anairam.Environment;

    [TestFixture]
    public class UserNameMatcherTest {
        [Test]
        public void ShouldMatchUserName() {
            var matcher = new UserNameMatcher(System.Environment.UserName) as Matcher;

            matcher.IsMatch().Should().BeTrue();
        }

        [Test]
        public void ShouldNotMatchUserName() {
            var matcher = new UserNameMatcher("nobody") as Matcher;

            matcher.IsMatch().Should().BeFalse();
        }
    }
}
