using System;

[assembly: System.Runtime.CompilerServices.IgnoresAccessChecksToAttribute("PrivateLibrary")]
namespace PrivateLibrary.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(new InternalClass().privateStringField);
        }
    }
}
