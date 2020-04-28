using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnCSharp.Basics.PrimitiveTypes.Dynamic
{
    [TestClass]
    public class Should
    {
        private object _target;
        private object _arg;

        [TestInitialize]
        public void TestInitialize()
        {
            _arg = "Cervantes";
            _target = "Albert, Cervantes";
        }

        [TestMethod]
        public void ShouldInvokeMethodThroughReflection()
        {
            var argTypes = new Type[] { _arg.GetType() };
            var method = _target.GetType().GetMethod("Contains", argTypes);
            var arguments = new object[] { _arg };
            var result = Convert.ToBoolean(method.Invoke(_target, arguments));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldInvokeMethodDynamically()
        {
            dynamic target = _target;
            dynamic arg = _arg;
            bool result = target.Contains(arg);
            Assert.IsTrue(result);
        }
    }
}