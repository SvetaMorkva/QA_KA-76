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
            int num1 = int.Parse(string.Concat(str1.Trim().Split('.')));
            int num2 = int.Parse(string.Concat(str2.Trim().Split('.')));
            if (num1 == num2 || Math.Max(num1, num2) / Math.Min(num1, num2) == 10)
                return 0;
            else if (num1 > num2)
                return 1;
            else
                return -1;
        }
    }
}
