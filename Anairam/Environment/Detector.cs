namespace Anairam {
    using Anairam.Environment;
    using System.Configuration;
    using System.Collections.Generic;

    public class Detector {
        static Detector() {
            SectionName = "environmentDetector";
        }

        private static string SectionName { get; set; }

        public static void SetSectionName(string name) {
            SectionName = name;
            current = null;
        }

        private static string current = null;
        public static string Current {
            get {
                return current ?? (current = GetCurrentEnvironment());
            }
        }

        private static string GetCurrentEnvironment() {
            var config = (DetectorConfigurationSection)ConfigurationManager.GetSection(SectionName);

            var matches = new List<EnvironmentElement>();
            foreach (var item in config.Environments) {
                if (item.Evaluate()) matches.Add(item);
            }

            if (matches.Count == 1)
                return matches[0].Name;
            else
                return config.Default;
        }
    }
}
