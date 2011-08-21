namespace Anairam.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class ExtensionTest {
        [Test]
        public void ShouldCapitalizeString() {
            var nome = "felipe";
            nome.Capitalize().Should().Eq("Felipe");
        }
    }
}
