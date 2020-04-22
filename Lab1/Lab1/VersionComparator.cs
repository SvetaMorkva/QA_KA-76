using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab1
{
    class VersionComparator
    {
        public static int CompareVersions(string version1, string version2)
        {
            List<string> splited_1 = new List<string>();
            if (version1.Contains(".") == true) 
            {

                splited_1 = version1.Split('.').ToList(); 
            }
            else
            {
                splited_1.Add(version1);
            }

            List<string> splited_2 = new List<string>();
            if (version2.Contains(".") == true)
            {
                splited_2 = version2.Split('.').ToList(); 
            }
            else
            {
                splited_2.Add(version2);
            }

            int i = 0;
         
            int max = Math.Max(splited_1.Count, splited_2.Count);
           
            while (splited_1.Count < splited_2.Count)
                splited_1.Add("0");

            while (splited_1.Count > splited_2.Count)
                splited_2.Add("0");
                
            
           while (i < max){
                if (int.Parse(splited_1[i]) > int.Parse(splited_2[i]))
                    return 1;
                else if (int.Parse(splited_1[i]) < int.Parse(splited_2[i]))
                    return -1;
                else if ((int.Parse(splited_1[i]) == int.Parse(splited_2[i])))
                    i++;
             }
            return 0;
        }
    }
}
