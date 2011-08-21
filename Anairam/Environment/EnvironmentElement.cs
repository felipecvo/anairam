namespace Anairam.Environment {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EnvironmentElement {
        public EnvironmentElement(string name) {
            Name = name;
            Matchers = new List<Matcher>();
        }

        public string Name { get; protected set; }
        public List<Matcher> Matchers { get; private set; }

        public void AddMatchers(string name, string value) {
            Matchers.Add(Matcher.Build(name, value));
        }

        public bool Evaluate() {
            var match = true;
            foreach (var item in Matchers) {
                match &= item.IsMatch();
            }
            return match;
        }
    }
}
