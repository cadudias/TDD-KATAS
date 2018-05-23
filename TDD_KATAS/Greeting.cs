using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_KATAS
{
    public class Greeting
    {
        private const string DefaultName = "my friend";
        private const string StartHello = "Hello";
        private const string StartShoutingGreet = "HELLO";

        public List<string> namesWithoutCommas = new List<string>();
        public List<string> uppercaseNames = new List<string>();
        public List<string> lowercaseNames = new List<string>();

        public string Greet(params string[] names)
        {
            if (names == null || names.Length == 0 || string.IsNullOrEmpty(names[0]))
                return ComposeSingleNormalGreet(DefaultName);

            // check if name is upper or lower and save it in the list
            foreach (var name in names)
            {
                // tetsa se a posicao do array tem virgula
                if (IsCommaSeparatted(name))
                {
                    RemoveCommas(namesWithoutCommas, name);
                }
                else
                {
                    namesWithoutCommas.Add(name);
                }
            }

            foreach (var item in namesWithoutCommas)
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

            string[] newUppercaseNames = AddCommasAndAndsTo(uppercaseNames);
            string[] newLowerNames = AddCommasAndAndsTo(lowercaseNames);

            if (HasOneLowerName(namesWithoutCommas, newUppercaseNames, newLowerNames))
            {
                return ComposeSingleNormalGreet(newLowerNames[0]);
            }
            else if (HasOneUpperName(namesWithoutCommas, newUppercaseNames, newLowerNames))
            {
                return ComposeSingleShoutingGreet(newUppercaseNames[0]);
            }
            else if (HasMoreThanOneLowerCaseNames(namesWithoutCommas, newUppercaseNames, newLowerNames))
            {
                return ComposeMultipleNormalGreet(newLowerNames);
            }
            else if (HasMoreThanOneLowerCaseAndUpperCaseNames(namesWithoutCommas, newUppercaseNames, newLowerNames))
            {
                return ComposeMultipleNormalGreet(newLowerNames) + ComposeMultipleShoutingGreet(newUppercaseNames);
            }

            return ComposeSingleNormalGreet(newLowerNames[0]);
        }

        private static bool HasMoreThanOneLowerCaseAndUpperCaseNames(List<string> namesWithoutCommas, string[] newUppercaseNames, string[] newLowerNames)
        {
            return namesWithoutCommas.Count() > 1 && newLowerNames.Length > 1 && newUppercaseNames.Length >= 1;
        }

        private static bool HasMoreThanOneLowerCaseNames(List<string> namesWithoutCommas, string[] newUppercaseNames, string[] newLowerNames)
        {
            return namesWithoutCommas.Count() > 1 && newLowerNames.Length > 1 && newUppercaseNames.Length == 0;
        }

        private static bool HasOneUpperName(List<string> namesWithoutCommas, string[] newUppercaseNames, string[] newLowerNames)
        {
            return namesWithoutCommas.Count() == 1 && newLowerNames.Length == 0 && newUppercaseNames.Length == 1;
        }

        private static bool HasOneLowerName(List<string> namesWithoutCommas, string[] newUppercaseNames, string[] newLowerNames)
        {
            return namesWithoutCommas.Count() == 1 && newLowerNames.Length == 1 && newUppercaseNames.Length == 0;
        }

        private string ComposeSingleNormalGreet(string defaultName)
        {
            return $"{StartHello}, {defaultName}.";
        }

        private string ComposeMultipleNormalGreet(string[] lowercaseNames)
        {
            return $"{StartHello}{string.Join("", lowercaseNames)}.";
        }

        private string ComposeSingleShoutingGreet(string defaultName)
        {
            return $"{StartShoutingGreet}, {defaultName}.".ToUpper();
        }

        private string ComposeMultipleShoutingGreet(string[] uppercaseNames)
        {
            return $" AND {StartShoutingGreet} {string.Join("", uppercaseNames)}.".ToUpper();
        }

        private static List<string> RemoveCommas(List<string> namesWithoutCommas, string name)
        {
            string[] newNames = name.Split(',');

            foreach (var newName in newNames)
            {
                namesWithoutCommas.Add(newName.Trim());
            }

            return namesWithoutCommas;
        }

        private static bool IsCommaSeparatted(string name)
        {
            //return names.Where(n => n.Contains(",")).Count() > 0;
            return name.Contains(',');
        }

        private static string[] AddCommasAndAndsTo(List<string> names)
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
