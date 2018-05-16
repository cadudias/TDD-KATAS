using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class Greeting
    {
        public static string Greet(string name)
        {
            name = (!string.IsNullOrEmpty(name) ? name : "my friend");

            string message = $"Hello, {name}.";

            return CheckIfIsUpper(name) ? message.ToUpper() : message;
        }

        private static bool CheckIfIsUpper(string name)
        {
            return name.All(c => char.IsUpper(c));
        }

        public static string GreetNames(string[] names)
        {
            string[] newNames = names.Select(n => !IsLast(n, names) ? ", " + n : ", and " + n).ToArray();

            string message = $"Hello{string.Join("", newNames)}.";

            return message;
        }

        private static bool IsLast(string n, string[] names)
        {
            return names.Last() == n;
        }
    }
}
