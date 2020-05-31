using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_BasicKnowledge
{
	public class MyVersion : IComparable
	{
		public MyVersion(string version)
		{
			var seps = new char[] { ' ', '.', ',', ':', ';' };
			try
			{
				int[] myInts = Array.ConvertAll(version.Split(seps), s => int.Parse(s));
				var list = myInts.ToList().Take(3).Append(0).Append(0);
				Major = list.ElementAt(0);
				Minor = list.ElementAt(1);
				Patch = list.ElementAt(2);

			}
			catch (Exception)
			{
				throw new ArgumentException("Please set a valid version. Like: 12.03.15");
			}

		}
		public MyVersion(string major, string minor, string patch)
		{
			try
			{
				Major = int.Parse(major);
				Minor = int.Parse(minor);
				Patch = int.Parse(patch);
			}
			catch (Exception)
			{
				throw new ArgumentException("Please set a valid version. Like: 12.03.15");
			}
		}
		public string Value => ToString();

		public int Major { get; set; }

		public int Minor { get; set; }

		public int Patch { get; set; }

		public  override string ToString()
		{
			return $"{Major}.{Minor}.{Patch}";
		}

		public int CompareTo(object obj)
		{
			MyVersion other = (MyVersion)obj;
			if (Major > other.Major)
				return 1;
			else if(Major == other.Major)
			{
				if (Minor > other.Minor)
					return 1;

				else if(Minor == other.Minor)
				{
					if (Patch > other.Patch)
						return 1;
					else if (Patch == other.Patch)
					{
						return 0;
					}
				}
			}
			return -1;
		}
	}
}
