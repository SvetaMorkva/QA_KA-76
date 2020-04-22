using System;

namespace Laba_1
{
    public class VersionComparator
    {
        static void Main() { }

        public int CompareVersions(string str1, string str2)
        {
            string[] split1 = str1.Trim().Split('.');
            string[] split2 = str2.Trim().Split('.');
            int length = Math.Max(split1.Length, split2.Length);

            for (int i = 0; i < length; i++)
            {
                int num1;
                if (split1.Length > i)
                    num1 = int.Parse(split1[i]);
                else
                    num1 = 0;

                int num2;
                if (split2.Length > i)
                    num2 = int.Parse(split2[i]);
                else
                    num2 = 0;


                if (num1 > num2)
                    return 1;
                else if (num1 < num2)
                    return -1;
            }

            return 0;
        }
    }
}