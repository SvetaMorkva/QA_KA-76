using System;
namespace Lab1
{
    public class VersionComparator
    {
        static public int Compare(string str1, string str2)
        {
            string split1 = str1.Replace(".", string.Empty);
            string split2 = str2.Replace(".", string.Empty);
            int version1 = int.Parse(split1);
            int version2 = int.Parse(split2);

            if (split1.Length > split2.Length)
            {
                string filledSplit2 = split2.PadRight(split1.Length, '0');
                version2 = int.Parse(filledSplit2);
            }
            else
            {
                string filledSplit1 = split1.PadRight(split2.Length, '0');
                version1 = int.Parse(filledSplit1);
            }

            return version1 == version2 ? 0 : (version1 > version2) ? 1 : -1;
        }
    }
}
