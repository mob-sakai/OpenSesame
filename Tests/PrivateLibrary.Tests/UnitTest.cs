using NUnit.Framework;

[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksTo("PrivateLibrary")]
namespace PrivateLibrary.Tests
{
    [TestFixture]
    public class UnitTest_Instance
    {
        [Test]
        public void PublicClass_privateStringField()
        {
            Assert.AreEqual(new PublicClass().privateStringField, "privateStringField");
        }

        [Test]
        public void InternalClass_privateStringField()
        {
            Assert.AreEqual(new InternalClass().privateStringField, "privateStringField");
        }

        [Test]
        public void PublicClass_PublicMethod()
        {
            Assert.AreEqual(new PublicClass().PublicMethod(), "PublicMethod");
        }

        [Test]
        public void InternalClass_PublicMethod()
        {
            Assert.AreEqual(new InternalClass().PublicMethod(), "PublicMethod");
        }

        [Test]
        public void PublicClass_PrivateMethod()
        {
            Assert.AreEqual(new PublicClass().PrivateMethod(), "PrivateMethod");
        }

        [Test]
        public void InternalClass_PrivateMethod()
        {
            Assert.AreEqual(new InternalClass().PrivateMethod(), "PrivateMethod");
        }
    }

    [TestFixture]
    public class UnitTest_Static
    {
        [Test]
        public void PublicClass_privateStaticStringField()
        {
            Assert.AreEqual(PublicClass.privateStaticStringField, "privateStaticStringField");
        }

        [Test]
        public void InternalClass_privateStaticStringField()
        {
            Assert.AreEqual(InternalClass.privateStaticStringField, "privateStaticStringField");
        }

        [Test]
        public void PublicClass_PublicStaticMethod()
        {
            Assert.AreEqual(PublicClass.PublicStaticMethod(), "PublicStaticMethod");
        }

        [Test]
        public void InternalClass_PublicStaticMethod()
        {
            Assert.AreEqual(InternalClass.PublicStaticMethod(), "PublicStaticMethod");
        }

        [Test]
        public void PublicClass_PrivateStaticMethod()
        {
            Assert.AreEqual(PublicClass.PrivateStaticMethod(), "PrivateStaticMethod");
        }

        [Test]
        public void InternalClass_PrivateStaticMethod()
        {
            Assert.AreEqual(InternalClass.PrivateStaticMethod(), "PrivateStaticMethod");
        }
    }

    [TestFixture]
    public class UnitTest_Static_Instance
    {
        [Test]
        public void PublicClass_PublicStaticMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", PublicClass.PublicStaticMethod(internalInstance));
        }

        [Test]
        public void InternalClass_PublicStaticMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", InternalClass.PublicStaticMethod(internalInstance));
        }

        [Test]
        public void PublicClass_PrivateStaticMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", PublicClass.PrivateStaticMethod(internalInstance));
        }

        [Test]
        public void InternalClass_PrivateStaticMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PrivateMethod", InternalClass.PrivateStaticMethod(internalInstance));
        }

        [Test]
        public void PublicClass_PublicMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", new PublicClass().PublicMethod(internalInstance));
        }

        [Test]
        public void InternalClass_PublicMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", new InternalClass().PublicMethod(internalInstance));
        }

        [Test]
        public void PublicClass_PrivateMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", new PublicClass().PrivateMethod(internalInstance));
        }

        [Test]
        public void InternalClass_PrivateMethod()
        {
            var internalInstance = new InternalClass();
            Assert.AreEqual("PrivateMethod", new InternalClass().PrivateMethod(internalInstance));
        }
    }


    [TestFixture]
    public class UnitTest_Static_Instance_2
    {
        private InternalClass _internalClass { get; set; }
        private PublicClass _publicClass { get; set; }


        [Test]
        public void InternalClass()
        {
            _internalClass = new InternalClass();
            Assert.AreEqual("PrivateMethod", new InternalClass().PrivateMethod(_internalClass));
        }

        [Test]
        public void PublicClass_PrivateMethod()
        {
            _internalClass = new InternalClass();
            _publicClass = new PublicClass();

            var internalInstance = new InternalClass();
            Assert.AreEqual("PublicMethod", _publicClass.PrivateMethod(_internalClass));
        }
    }
}
