namespace Anairam.Test {
    using System;
    using NUnit.Framework;


    public class Expectation {
        public Expectation(object obj, bool negative) {
            Negative = negative;
            Object = obj;
        }

        public bool Negative { get; set; }
        public object Object { get; set; }
        public void AssertExpectation(Action func) {
            func();

        }
    }

    public static class Shoulds {
        public static Expectation Should(this object obj) {
            return new Expectation(obj, false);
        }

        public static Expectation ShouldNot(this object obj) {
            return new Expectation(obj, true);
        }

        public static Expectation BeNull(this Expectation obj) {
            obj.AssertExpectation(delegate() {
                if (obj.Negative) {
                    Assert.IsNotNull(obj.Object);
                } else {
                    Assert.IsNull(obj.Object);
                }
            });

            return obj;
        }

        public static Expectation Eq(this Expectation obj, object value) {
            obj.AssertExpectation(delegate() {
                if (obj.Negative) {
                    Assert.AreNotEqual(value, obj.Object);
                } else {
                    Assert.AreEqual(value, obj.Object);
                }
            });

            return obj;
        }

        public static Expectation BeFalse(this Expectation obj) {
            obj.AssertExpectation(delegate() {
                if (obj.Negative) {
                    Assert.IsTrue((bool)obj.Object);
                } else {
                    Assert.IsFalse((bool)obj.Object);
                }
            });

            return obj;
        }

        public static Expectation BeTrue(this Expectation obj) {
            obj.AssertExpectation(delegate() {
                if (obj.Negative) {
                    Assert.IsFalse((bool)obj.Object);
                } else {
                    Assert.IsTrue((bool)obj.Object);
                }
            });

            return obj;
        }

        public static Expectation BeA(this Expectation obj, Type expectedType) {
            obj.AssertExpectation(delegate() {
                if (obj.Negative) {
                    Assert.IsNotInstanceOf(expectedType, obj.Object);
                } else {
                    Assert.IsInstanceOf(expectedType, obj.Object);
                }
            });

            return obj;
        }
    }
}
