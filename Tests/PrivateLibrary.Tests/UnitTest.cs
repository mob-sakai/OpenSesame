using NUnit.Framework;

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
}
