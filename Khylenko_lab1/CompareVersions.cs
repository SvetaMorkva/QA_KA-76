using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khylenko_lab1
{
    class CompareVersions
    {
        public static int Versions(string str1, string str2)
        {
            string split_str1 = str1.Replace(".", string.Empty);
            string split_str2 = str2.Replace(".", string.Empty);

            int len_str1 = split_str1.Length;
            int len_str2 = split_str2.Length;

            int num1 = int.Parse(split_str1);
            int num2 = int.Parse(split_str2);

            if (len_str1 > len_str2)
                num2 = int.Parse(split_str2.PadRight(len_str1, '0'));
            else
                num1 = int.Parse(split_str1.PadRight(len_str2, '0'));

            if (num1 == num2)
                return 0;
            else if (num1 > num2)
                return 1;
            else
                return -1;
        }
    }
}
