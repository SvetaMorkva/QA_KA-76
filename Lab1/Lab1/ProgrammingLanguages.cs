using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ProgrammingLanguage
    {
        public string name { get; set; }
        public int years { get; set; }

        public string Print()
        {
            return string.Format("Language {0} is {1} years old", name, years);
        }
    }

    public class Mock
    {
        public static LinkedList<ProgrammingLanguage> languages = new LinkedList<ProgrammingLanguage>();
        public static void AddLanguages()
        {
            languages.Add(new ProgrammingLanguage { years = 15, name = "Python" });
            languages.Add(new ProgrammingLanguage { years = 18, name = "C#" });
            languages.Add(new ProgrammingLanguage { years = 20, name = "JavaScript" });
            languages.Add(new ProgrammingLanguage { years = 30, name = "C++" });
            languages.Add(new ProgrammingLanguage { years = 35, name = "C" });
        }
    }
}
