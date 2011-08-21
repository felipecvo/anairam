namespace Anairam {
    using System.Configuration;
    using System.Xml;

    public class EnvironmentConfigurationSection : IConfigurationSectionHandler {
        public string Default { get; set; }

        public object Create(object parent, object configContext, XmlNode section) {
            this.Default = section.Attributes["default"].Value;
            return this;
        }
    }
}
