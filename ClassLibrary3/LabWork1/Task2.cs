using System;
namespace ClassLibrary3
{
    public class Task2
    {
        public int CompareVersions(String version1, String version2)
        {
            for (int i = 0; i < Math.Max(version1.Split('.').Length, version2.Split('.').Length); i++)
            {
                if ((i < version1.Split('.').Length) && (i < version2.Split('.').Length))
                {
                    if (Int32.Parse(version1.Split('.')[i]) > Int32.Parse(version2.Split('.')[i]))
                    {
                        return 1;
                    }
                    else if (Int32.Parse(version1.Split('.')[i]) < Int32.Parse(version2.Split('.')[i]))
                    {
                        return -1;
                    }

                }
                else if (i >= version1.Split('.').Length)
                {
                    if (0 > Int32.Parse(version2.Split('.')[i]))
                    {
                        return 1;
                    }
                    else if (0 < Int32.Parse(version2.Split('.')[i]))
                    {
                        return -1;
                    }
                }

                else if (i >= version2.Split('.').Length)
                {
                    if (0 > Int32.Parse(version1.Split('.')[i]))
                    {
                        return -1;
                    }
                    else if (0 < Int32.Parse(version1.Split('.')[i]))
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}