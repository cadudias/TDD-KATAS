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
            //names.Select(n => IsCommaSeparatted(n) ? n.Split(',') : n).ToArray();
            List<string> newArray = new List<string>();
            List<string> uppercaseNames = new List<string>();
            List<string> lowercaseNames = new List<string>();

            // check if name is upper or lower and save it in the list
            foreach (var name in names)
            {
                // tetsa se a posicao do array tem virgula
                if (IsCommaSeparatted(name))
                {
                    // se tem cria um novo array com os nomes separados
                    string[] newNames = name.Split(',');

                    foreach (var newName in newNames)
                    {
                        newArray.Add(newName.Trim());
                    }
                }
                else
                {
                    newArray.Add(name);
                }
            }

            foreach (var item in newArray)
            {
                if (IsUpper(item))
                {
                    uppercaseNames.Add(item);
                }
                else
                {
                    lowercaseNames.Add(item);
                }
            }

            string[] newUppercaseNames = CreatePhrase(uppercaseNames);

            string[] newLowerNames = CreatePhrase(lowercaseNames);

            string phraseLower = $"Hello{string.Join("", newLowerNames)}.";

            string phraseUpper = $" AND HELLO {string.Join("", newUppercaseNames)}.".ToUpper();

            return phraseLower + (uppercaseNames.Count > 0 ? phraseUpper : "");
        }

        private static bool IsCommaSeparatted(string name)
        {
            //return names.Where(n => n.Contains(",")).Count() > 0;
            return name.Contains(',');
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
