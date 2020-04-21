using System;
using System.Text;

namespace lab1
{
    public class VersionComparator
    {
        public int compareVersions(string version1, string version2)
        {
            /*
                Method, which takes as parameters 2 strings.
                These strings are product versions (semantic versioning).
                Product version consists of unlimited versions and subversions.
                Pattern for version is numbers and dot delimiters.
                If first version is greater than second method returns 1,
                if equals 0, if less -1.
                
                Examples:
                str1 = “1.2.3” str2 = “4.5.6” return -1
                str1 = “1” str2 = “1.0” return 0
                str1 = “1.1.0” str2 = “1.0.1” return 1
            */

            version1 = completeVersion(version1);
            version2 = completeVersion(version2);

            int v1 = Int32.Parse(version1.Replace(".", ""));
            int v2 = Int32.Parse(version2.Replace(".", ""));

            if (v2 > v1)
            {
                return -1;
            }
            else if (v1 > v2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string completeVersion(string version)
        {
            StringBuilder sb = new StringBuilder(version);
            if (version.Length <= 2)
            {
                return sb.Append(".0.0").ToString();
            }
            else if(version.Length <= 4)
            {
                return sb.Append(".0").ToString();
            }
            return version;
        }
    }
}
