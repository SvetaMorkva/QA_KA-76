using System;
namespace Lab1
{
    public class VersionComparator
    {
        static public int Compare(string str1, string str2)
        {
            var version1 = new Version(str1);
            var version2 = new Version(str2);

            var result = version1.CompareTo(version2);
            if (result > 0)
            {
                Console.WriteLine("version1 is greater");
                return 1;
            }
            else if (result < 0)
            {
                Console.WriteLine("version2 is greater");
                return -1;
            }
            else
            {
                Console.WriteLine("versions are equal");
                return 0;
            }
        }
    }
}
