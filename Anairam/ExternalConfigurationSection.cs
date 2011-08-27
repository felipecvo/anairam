namespace Anairam {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using System.Xml;

    /// <summary>
    /// Configuration section handler that support data configuration to be defined
    /// in an external file.
    /// </summary>
    /// <example>
    /// &lt;myConfig file="Config/myConfig.config" /&gt;
    /// </example>
    public class ExternalConfigurationSection : IConfigurationSectionHandler {
        public object Create(object parent, object configContext, XmlNode section) {
            if (section.Attributes["file"] != null) {
                var xml = new XmlDocument();
                xml.Load(section.Attributes["file"].Value);
                section = xml.DocumentElement;
            }

            LoadValues(section);

            return this;
        }

        protected virtual void LoadValues(XmlNode section) {
            var type = this.GetType();

            foreach (XmlAttribute attribute in section.Attributes) {
                if (attribute.Name == "file") continue;
                type.GetProperty(attribute.Name.Capitalize()).SetValue(this, attribute.Value, null);
            }

            foreach (XmlNode children in section.ChildNodes) {
                type.GetProperty(children.Name.Capitalize()).SetValue(this, children.InnerText, null);
            }
        }
    }
}