using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Version_Comparer
    {
        public static int CompareVersions(string str1, string str2)
        {
            string[] splited_str1 = str1.Trim().Split('.');
            string[] splited_str2 = str2.Trim().Split('.');

            int len_str1 = splited_str1.Length;
            int len_str2 = splited_str2.Length;

            int num1 = int.Parse(string.Concat(splited_str1));
            int num2 = int.Parse(string.Concat(splited_str2));

            if (len_str1 > len_str2)
                num2 *= Convert.ToInt32(Math.Pow(10.0, len_str1 - len_str2));
            else
                num1 *= Convert.ToInt32(Math.Pow(10.0, len_str2 - len_str1));

            if (num1 == num2)
                return 0;
            else {

                if (num1 > num2)
                    return 1;
                else
                    return -1;
            }
        }
    }
}
