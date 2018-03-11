using System;
using TestLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeter = new Greeter("World");
            Console.WriteLine(greeter.Greet());
        }
    }
}
