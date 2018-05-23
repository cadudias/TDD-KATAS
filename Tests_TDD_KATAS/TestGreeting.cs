using NUnit.Framework;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{

    class TestGreeting
    {
        private Greeting greeting;

        [SetUp]
        public void SetUp()
        {
            greeting = new Greeting();
        }

        [Test]
        public void Greeting_ShouldGreetWithGivenName()
        {
            var sut = greeting.Greet("Bob");

            Assert.AreEqual(sut, "Hello, Bob.");
        }

        [Test]
        public void Greeting_ShouldGreetWithDefaultValueIfNameIsNull()
        {
            var sut = greeting.Greet(null);

            Assert.AreEqual(sut, "Hello, my friend.");
        }

        [Test]
        public void Greeting_ShouldShoutIfNameIsUppercase()
        {
            var sut = greeting.Greet("JERRY");

            Assert.AreEqual(sut, "HELLO, JERRY.");
        }

        [Test]
        public void Greeting_ShouldGreetTwoPersons()
        {
            var sut = greeting.Greet("Jill", "Jane");

            Assert.AreEqual(sut, "Hello, Jill and Jane.");
        }

        [Test]
        public void Greeting_ShouldGreetMultiplePersons()
        {
            var sut = greeting.Greet("Amy", "Brian", "Charlotte");

            Assert.AreEqual(sut, "Hello, Amy, Brian, and Charlotte.");
        }

        // Requirement 6
        [Test]
        public void Greeting_ShouldGreetMultiplePersonsWithUppercaseAndLowercase()
        {
            var sut = greeting.Greet("Amy", "BRIAN", "Charlotte");

            Assert.AreEqual(sut, "Hello, Amy and Charlotte. AND HELLO BRIAN.");
        }

        // Requirement 7
        [Test]
        public void Greeting_ShouldGreetEvenIfStringContainsComma()
        {
            var sut = greeting.Greet("Bob", "Charlie, Dianne");

            Assert.AreEqual(sut, "Hello, Bob, Charlie, and Dianne.");
        }

        //// Requirement 8
        //[Test]
        //public void Greeting_ShouldGreetEvenIfStringContainsCommaAndAllowEscape()
        //{
        //    string[] names = new string[] { "Bob", ""Charlie, Dianne"" };

        //    string sut = Greeting.Greet(names);

        //    Assert.AreEqual(sut, "Hello, Bob, Charlie, and Dianne.");
        //}
    }
}
