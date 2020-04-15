using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Task2
    {
        private List<int> parseToInt(string[] str)
        {
            List<int> value = new List<int>();
            foreach (string split in str)
            {
                if (Int32.TryParse(split, out int check))
                {
                    value.Add(int.Parse(split));
                }
                else Console.Write("ERROR: not valid value " + split + " in " + str);
            }
            return value;
        }
        public int CompareVersions(string str1, string str2)
        {
            string[] str1_splits = str1.Split('.');
            string[] str2_splits = str2.Split('.');
            List<int> v1 = new List<int>();
            List<int> v2 = new List<int>();
            v1 = parseToInt(str1_splits);
            v2 = parseToInt(str2_splits);

            while (v1.Count - v2.Count > 0) v2.Add(0);
            while (v1.Count - v2.Count < 0) v1.Add(0);
            
            int res = 0;
            for (int i = 0; i < v1.Count; i++)
            {
                if (v1[i] > v2[i]) { res = 1; break; }
                else if (v1[i] < v2[i]) { res = -1; break; }
            }

            return res;
        }
    }
}
