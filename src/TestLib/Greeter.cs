using System;

namespace TestLib
{
    public class Greeter
    {
        public string Name { get; }

        public string Greet()
        {
            return $"Hello {Name}";
        }

        public Greeter(string name)
        {
            Name = name;
        }
    }
}
