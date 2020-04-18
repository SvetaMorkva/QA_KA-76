using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class Comparer
    {
        public static int CompareVersions(string version1, string version2)
        {
            List<string> version1List = version1.Trim().Split('.').ToList();
            List<string> version2List = version2.Trim().Split('.').ToList();

            int diff = Math.Abs(version1List.Count - version2List.Count);
            
            for (int i = 0; i < diff; i++)
            {
                if (version1List.Count > version2List.Count)
                {
                    version2List.Add("0");
                }
                else
                {
                    version1List.Append("0");
                }
            }

            for (int i = 0; i < version1List.Count; i++)
            {
                int num1 = int.Parse(version1List[i]);
                int num2 = int.Parse(version2List[i]);
                if (num1 > num2)
                {
                    return 1;
                }
                if (num1 < num2)
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}