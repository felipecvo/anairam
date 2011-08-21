namespace Anairam.Environment {
    using System.Configuration;
    using System.Xml;
using System.Collections.Generic;

    /// <summary>
    /// Load environment detector configuration from config file
    /// </summary>
    /// <remarks>
    /// All environments constrains defined in config file will be available in this class.
    /// This class is used by <see cref="Anairam.Detector"/> to evaluate the
    /// constraints and identify current environment.
    /// </remarks>
    public class DetectorConfigurationSection : IConfigurationSectionHandler {
        /// <summary>
        /// Default environment to be used. If none constrain match, this value will be returned
        /// by <see cref="Anairam.Detector"/>.
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// List of environments defined in config file. One of it would be evaluated as current environment.
        /// </summary>
        public List<EnvironmentElement> Environments { get; private set; }

        /// <summary>
        /// Create a <see cref="Anairam.EnvironmentDetectorConfiguration"/> from config file.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section">XmlNode read from config file</param>
        /// <returns>A <see cref="Anairam.EnvironmentDetectorConfiguration"/> filled with config data.</returns>
        public object Create(object parent, object configContext, XmlNode section) {
            Default = section.Attributes["default"].Value;

            Environments = new List<EnvironmentElement>();

            foreach (XmlNode node in section.SelectNodes("//environment")) {
                var env = new EnvironmentElement(node.Attributes["name"].Value);

                foreach (XmlNode children in node.ChildNodes) {
                    if (children.NodeType == XmlNodeType.Comment) continue;
                    env.AddMatchers(children.Name, children.Attributes["value"].Value);
                }

                Environments.Add(env);
            }

            return this;
        }
    }
}
