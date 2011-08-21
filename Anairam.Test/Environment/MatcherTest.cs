namespace Anairam.Test.Environment {
    using NUnit.Framework;
using Anairam.Environment;
    using System;

    [TestFixture]
    public class MatcherTest {
        [Test]
        public void ShouldBuildMachineNameMatcher() {
            var matcher = Matcher.Build("machineName", "bubblebee");

            matcher.Should().BeA(typeof(MachineNameMatcher));
            matcher.Value.Should().Eq("bubblebee");
        }

        [Test]
        public void ShouldBuildUserNameMatcher() {
            var matcher = Matcher.Build("userName", "jack");

            matcher.Should().BeA(typeof(UserNameMatcher));
            matcher.Value.Should().Eq("jack");
        }

        [Test]
        public void ShouldBuildProcessorCountMatcher() {
            var matcher = Matcher.Build("processorCount", "2");

            matcher.Should().BeA(typeof(ProcessorCountMatcher));
            matcher.Value.Should().Eq("2");
        }

        [Test]
        [ExpectedException(ExpectedException=typeof(InvalidOperationException))]
        public void ShouldRaiseWithUnknownMatcher() {
            Matcher.Build("unknown", "raise,please!");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void ShouldRaiseWithWrongType() {
            Matcher.Build("", "wrong type");
        }
    }
}
