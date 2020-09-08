using System;
using PrivateLibrary.Bridges;

namespace PrivateLibrary.Console
{
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
