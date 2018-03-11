using System;
using Xunit;
using TestLib;

namespace TestLib.Tests
{
    public class GreeterTests
    {   
        [Fact]
        public void Should_Greet_Hello_World()
        {
            // Given
            var greeter = new Greeter("World");

            // When
            var greeting = greeter.Greet();

            // Then
            Assert.Equal("Hello World", greeting);
        }
    }
}
