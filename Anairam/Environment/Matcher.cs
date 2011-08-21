using System;
namespace Anairam.Environment {
    public abstract class Matcher {
        public Matcher(string value) {
            Value = value;
        }

        public string Value { get; protected set; }

        public abstract bool IsMatch();

        public static Matcher Build(string name, string value) {
            name = string.Format("{0}Matcher", name).Capitalize();
            var types = typeof(Matcher).Assembly.GetTypes();
            Type type = null;

            foreach (var item in types) {
                if (item.Name == name && item.IsSubclassOf(typeof(Matcher))) {
                    type = item;
                }
            }

            if (type == null)
                throw new InvalidOperationException(string.Format("Unknown matcher type '{0}'", name));

            return Activator.CreateInstance(type, value) as Matcher;
        }
    }
}