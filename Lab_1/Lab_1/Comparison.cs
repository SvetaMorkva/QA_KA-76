using System;

namespace Lab_1
{
    class Comparison
    {
        public int CompareVersions(string str1, string str2)
        {
            string[] version1 = str1.Trim().Split('.');
            string[] version2 = str2.Trim().Split('.');
            int length = Math.Max(version1.Length, version2.Length);

            for (int i = 0; i < length; i++)
            {
                int n1;
                if (version1.Length > i)
                    n1 = int.Parse(version1[i]);
                else
                    n1 = 0;

                int n2;
                if (version2.Length > i)
                    n2 = int.Parse(version2[i]);
                else
                    n2 = 0;


                if (n1 > n2)
                    return 1;
                else if (n1 < n2)
                    return -1;
            }
            return 0;
        }
    }
}