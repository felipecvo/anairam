namespace Anairam.Test {
    using NUnit.Framework;
    using System.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExternalConfigurationSectionTest {
        [Test]
        public void ShouldGetSectionFromSameConfig() {
            var section = (MoviesConfigurationSection)ConfigurationManager.GetSection("movies");
            section.ShouldNot().BeNull();
            section.Category.Should().Eq("Action");
            section.MediaType.Should().Eq("BluRay");
        }

        [Test]
        public void ShouldGetSectionFromExternalConfig() {
            var section = (MoviesConfigurationSection)ConfigurationManager.GetSection("classicMovies");
            section.ShouldNot().BeNull();
            section.Category.Should().Eq("Classic");
            section.MediaType.Should().Eq("Cassete");
        }
    }

    public sealed class MoviesConfigurationSection : ExternalConfigurationSection {
        public string MediaType { get; set; }
        public string Category { get; set; }
    }
}
