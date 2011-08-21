namespace Anairam.Environment {
    public class ProcessorCountMatcher : Matcher {
        public ProcessorCountMatcher(string value) : base(value) {}

        public override bool IsMatch() {
            return System.Environment.ProcessorCount.ToString().Equals(Value);
        }
    }
}
