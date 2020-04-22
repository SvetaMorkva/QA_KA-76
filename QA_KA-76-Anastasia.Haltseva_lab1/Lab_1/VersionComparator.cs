using System;

namespace Lab_1
{
	public class VersionComparator
	{
		public int CompareVersions(string v1, string v2)
		{
			string[] split1 = v1.Trim().Split('.');
			string[] split2 = v2.Trim().Split('.');
			int length = Math.Max(split1.Length, split2.Length);

			for (int i = 0; i < length; i++)
			{
				int num1;
				if (split1.Length > i)
					num1 = int.Parse(split1[i]);
				else
					num1 = 0;

				int num2;
				if (split2.Length > i)
					num2 = int.Parse(split2[i]);
				else
					num2 = 0;


				if (num1 > num2)
					return 1;
				else if (num1 < num2)
					return -1;
			}

			return 0;
		}
	}
}