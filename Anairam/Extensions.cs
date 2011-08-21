namespace Anairam {
    /// <summary>
    /// This class contains extensions methods, used by this library
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// Capitalize transform the first letter of a string into upcase
        /// </summary>
        /// <param name="str">Extend string class</param>
        /// <returns>String capitalized</returns>
        /// <example>
        /// var name = "felipe";
        /// Console.WriteLine(name.Capitalize()); // This will print "Felipe"
        /// </example>
        public static string Capitalize(this string str) {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
    }
}
