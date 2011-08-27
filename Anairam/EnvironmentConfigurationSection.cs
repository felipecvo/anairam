namespace Anairam {
    using System.Configuration;
    using System.Xml;
    using Anairam.Environment;

    public class EnvironmentConfigurationSection : ExternalConfigurationSection {
        protected override void LoadValues(XmlNode section) {
            var environment = section.SelectSingleNode(Detector.Current);

            base.LoadValues(environment);
        }
    }
}
