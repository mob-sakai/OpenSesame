using System;

[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksToAttribute("PrivateLibrary")]
namespace PrivateLibrary.Bridges
{
    /// <summary>
    /// Internal Class Bridge
    /// </summary>
    public class InternalClassBridge
    {
        /// <summary>
        /// private String Field
        /// </summary>
        public string privateStringField = new InternalClass().privateStringField;

        /// <summary>
        /// private Static String Field
        /// </summary>
        public static string privateStaticStringField = InternalClass.privateStaticStringField;

        /// <summary>
        /// Public Static Method
        /// </summary>
        public static string PublicStaticMethod()
        {
            return InternalClass.PublicStaticMethod();
        }


        /// <summary>
        /// Private Static Method
        /// </summary>
        public static string PrivateStaticMethod()
        {
            return InternalClass.PrivateStaticMethod();
        }


        /// <summary>
        /// Public Method
        /// </summary>
        public string PublicMethod()
        {
            return new InternalClass().PublicMethod();
        }


        /// <summary>
        /// Private Method
        /// </summary>
        public string PrivateMethod()
        {
            return new InternalClass().PrivateMethod();
        }
    }
}
