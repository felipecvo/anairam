namespace Anairam.Environment {
    public class UserNameMatcher : Matcher {
        public UserNameMatcher(string value) : base(value) { }

        public override bool IsMatch() {
            return System.Environment.UserName.Equals(Value);
        }
    }
}
