namespace Anairam.Environment {
    public class MachineNameMatcher : Matcher {
        public MachineNameMatcher(string value) : base(value) { }

        public override bool IsMatch() {
            return System.Environment.MachineName.Equals(Value);
        }
    }
}
