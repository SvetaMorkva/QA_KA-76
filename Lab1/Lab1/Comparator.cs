using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Comparator
    {
        public int CompareVersions(string str1, string str2)
        {
            string strWithoutSpaces1 = str1.Trim();
            string strWithoutSpaces2 = str2.Trim();

            var version1 = new Version(strWithoutSpaces1);
            var version2 = new Version(strWithoutSpaces2);

            var result = version1.CompareTo(version2);
            Console.WriteLine(result);
            if (result > 0)
                return 1;
            else if (result < 0)
                return -1;
            else
                return 0;
        }
    }
}
