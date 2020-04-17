using System;

namespace Task2
{
    class Program
    {
        public int CompareVersions (string version1, string version2)
        {
            int[] v1 = new int[3] { 0, 0, 0 };
            int[] v2 = new int[3] { 0, 0, 0 };
            char spearator = '.';
            string[] versionTmp1 = version1.Split(spearator);
            string[] versionTmp2 = version2.Split(spearator);
            int i = 0;
            foreach (string s in versionTmp1)
            {
                v1[i] = int.Parse(s);
                i++;
            }
            i = 0;
            foreach (string s in versionTmp2)
            {
                v2[i] = int.Parse(s);
                i++;
            }
            for(int j = 0; j < 3; j++)
            {
                if (v1[j] < v2[j])
                    return -1;
                else if (v1[j] > v2[j])
                    return 1;
            }
            return 0;
        }
        static void Main(string[] args)
        {

        }
    }
}
