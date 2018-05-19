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

            return IsUpper(name) ? message.ToUpper() : message;
        }

        public static string GreetNames(string[] names)
        {
            List<string> uppercaseNames = new List<string>();
            List<string> lowercaseNames = new List<string>();

            // check if name is upper or lower and save it in the list
            foreach (var name in names)
            {
                if (IsUpper(name))
                {
                    uppercaseNames.Add(name);
                }
                else
                {
                    lowercaseNames.Add(name);
                }
            }

            // se tem uppercase names
            //  tem que colocar eles numa frase separada 
            // monta uma frase com virgulas pra lowercase

            // monta frase com virgulas pra uppercase

            string[] newUppercaseNames = CreatePhrase(uppercaseNames);

            string[] newLowerNames = CreatePhrase(lowercaseNames);

            string phraseLower = $"Hello{string.Join("", newLowerNames)}.";

            string phraseUpper = $" AND HELLO {string.Join("", newUppercaseNames)}.".ToUpper();

            return phraseLower + (uppercaseNames.Count > 0 ? phraseUpper : "");
        }

        private static string[] CreatePhrase(List<string> names)
        {
            return names.Select(n =>
            names.Count == 2 ?
                (!IsLast(n, names) ? ", " + n : " and " + n) :
            names.Count > 2 ?
                (!IsLast(n, names) ? ", " + n : ", and " + n) : n).ToArray();
        }

        private static bool IsLast(string n, List<string> names)
        {
            return names.Last() == n;
        }

        private static bool IsUpper(string name)
        {
            return name.All(c => char.IsUpper(c));
        }
    }
}
