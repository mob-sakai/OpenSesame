using System;

namespace PrivateLibrary
{
    /// <summary>
    /// Public class
    /// </summary>
    public class PublicClass
    {
        /// <summary>
        /// private String Field
        /// </summary>
        private string privateStringField = "privateStringField";

        /// <summary>
        /// private Static String Field
        /// </summary>
        private static string privateStaticStringField = "privateStaticStringField";

        /// <summary>
        /// Public Static Method
        /// </summary>
        public static string PublicStaticMethod()
        {
            return "PublicStaticMethod";
        }

        /// <summary>
        /// Private Static Method
        /// </summary>
        private static string PrivateStaticMethod()
        {
            return "PrivateStaticMethod";
        }

        /// <summary>
        /// Public Method
        /// </summary>
        public string PublicMethod()
        {
            return "PublicMethod";
        }

        /// <summary>
        /// Private Method
        /// </summary>
        private string PrivateMethod()
        {
            return "PrivateMethod";
        }

        /// <summary>
        /// Public Static Method
        /// </summary>
        internal static string PublicStaticMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }

        /// <summary>
        /// Private Static Method
        /// </summary>
        private static string PrivateStaticMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }

        /// <summary>
        /// Public Method
        /// </summary>
        internal string PublicMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }

        /// <summary>
        /// Private Method
        /// </summary>
        private string PrivateMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }
    }

    /// <summary>
    /// Internal Class
    /// </summary>
    internal class InternalClass
    {
        /// <summary>
        /// private String Field
        /// </summary>
        private string privateStringField = "privateStringField";

        /// <summary>
        /// private Static String Field
        /// </summary>
        private static string privateStaticStringField = "privateStaticStringField";

        /// <summary>
        /// Public Static Method
        /// </summary>
        public static string PublicStaticMethod()
        {
            return "PublicStaticMethod";
        }


        /// <summary>
        /// Private Static Method
        /// </summary>
        private static string PrivateStaticMethod()
        {
            return "PrivateStaticMethod";
        }


        /// <summary>
        /// Public Method
        /// </summary>
        public string PublicMethod()
        {
            return "PublicMethod";
        }


        /// <summary>
        /// Private Method
        /// </summary>
        private string PrivateMethod()
        {
            return "PrivateMethod";
        }

        /// <summary>
        /// Public Static Method
        /// </summary>
        public static string PublicStaticMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }

        /// <summary>
        /// Private Static Method
        /// </summary>
        private static string PrivateStaticMethod(InternalClass instance)
        {
            return instance.PrivateMethod();
        }

        /// <summary>
        /// Public Method
        /// </summary>
        public string PublicMethod(InternalClass instance)
        {
            return instance.PublicMethod();
        }

        /// <summary>
        /// Private Method
        /// </summary>
        private string PrivateMethod(InternalClass instance)
        {
            return instance.PrivateMethod();
        }
    }
}
