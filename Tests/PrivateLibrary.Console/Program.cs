using System;
using PrivateLibrary.Bridges;

[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksTo("PrivateLibrary")]
namespace PrivateLibrary.Console
{
    internal class InheritClass : PrivateLibrary.InternalClass
    {
        public override string PublicMethod()
        {
            return "PublicMethod (InheritClass)";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(InternalClassBridge.privateStaticStringField);
            System.Console.WriteLine(InternalClassBridge.PublicStaticMethod());
            System.Console.WriteLine(InternalClassBridge.PrivateStaticMethod());
            System.Console.WriteLine(new InternalClassBridge().privateStringField);
            System.Console.WriteLine(new InternalClassBridge().PublicMethod());
            System.Console.WriteLine(new InternalClassBridge().PrivateMethod());
        }
    }
}
