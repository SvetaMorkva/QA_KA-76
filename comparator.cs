using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Lab1
{
    public class Comparator
    {
        public static int CompareVersions(string version1, string version2)
        {
            List<string> listv1 = version1.Trim().Split('.').ToList();
            List<string> listv2 = version2.Trim().Split('.').ToList();

            int substraction = Math.Abs(listv1.Count - listv2.Count);
            
            for (int i=0; i < substraction; i++)
            {
                if (listv1.Count > listv2.Count)
                {
                    listv2.Add("0");
                }
                else
                {
                    listv1.Add("0");
                }
            }

            for (int i = 0; i < listv1.Count; i++)
            {
                int num1 = int.Parse(listv1[i]);
                int num2 = int.Parse(listv2[i]);
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