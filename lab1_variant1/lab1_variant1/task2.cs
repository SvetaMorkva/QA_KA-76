using System;

namespace lab1_variant1
{
    public class CompareVersions
    {
        // Write С# CompareVersions() method, which takes as parameters 2 strings.
        // These strings are product versions. Product version consists of unlimited versions and subversions.
        // Pattern for version is numbers and dot delimiters. If first version is greater than second method returns 1, if equals 0,
        // if less -1.
        // Examples:
        // str1 = “1.2.3” str2 = “4.5.6” return -1
        // str1 = “1” str2 = “1.0” return 0
        // str1 = “1.1.0” str2 = “1.0.1” return 1

        private string v1;
        private string v2;

        public CompareVersions(string version1, string version2)
        {
            v1 = version1;
            v2 = version2;
        }

        private string[] FillArrToSize(string[] array, int newSize)
        {
            int s1 = array.Length;
            Array.Resize<string>(ref array, newSize);
            for (int i = s1; i < newSize; i++)
                array[i] = "0";

            return array;
        }

        private int CompareMain()
        {
            char sep = '.';
            string[] v1List = v1.Split(sep);
            string[] v2List = v2.Split(sep);

            int lenDiff = v1List.Length - v2List.Length;
            if (lenDiff != 0)
            {
                int newLen = Math.Max(v1List.Length, v2List.Length);
                if (lenDiff < 0)
                {
                    v1List = FillArrToSize(v1List, newLen);
                }
                else
                {
                    v2List = FillArrToSize(v2List, newLen);
                }
            }

            for (int i = 0; i < v1List.Length; i++)
            {
                int n1 = Int32.Parse(v1List[i]);
                int n2 = Int32.Parse(v2List[i]);

                if (n1 > n2)
                    return 1;
                if (n1 < n2)
                    return -1;
            }
            return 0;
        }

        public int Compare => CompareMain();
    }
}
