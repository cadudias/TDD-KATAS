using NUnit.Framework;
using TDD_KATAS;

namespace Tests_TDD_KATAS
{

    class TestGreeting
    {
        [Test]
        public void Greeting_ShouldGreetWithGivenName()
        {
            string sut = Greeting.Greet("Bob");

            Assert.AreEqual(sut, "Hello, Bob.");
        }

        [Test]
        public void Greeting_ShouldGreetWithDefaultValueIfNameIsNull()
        {
            string sut = Greeting.Greet(null);

            Assert.AreEqual(sut, "Hello, my friend.");
        }

        [Test]
        public void Greeting_ShouldShoutIfNameIsUppercase()
        {
            string sut = Greeting.Greet("JERRY");

            Assert.AreEqual(sut, "HELLO, JERRY.");
        }

        [Test]
        public void Greeting_ShouldGreetTwoPersons()
        {
            string[] names = new string[] { "Jill", "Jane", "" };

            string sut = Greeting.GreetNames(names);

            Assert.AreEqual(sut, "Hello, Jill and Jane.");
        }

        [Test]
        public void Greeting_ShouldGreetMultiplePersons()
        {
            string[] names = new string[] { "Amy", "Brian", "Charlotte" };

            string sut = Greeting.GreetNames(names);

            Assert.AreEqual(sut, "Hello, Amy, Brian, and Charlotte.");
        }
    }
}
