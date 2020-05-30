using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
	public class People
	{
		public string name { get; set; }

		public string String()
		{
			return string.Format("Person`s ", name);
		}
	}


	public class Items
	{
		public Queue<People> queue { get; }

		public Items(int n = 6)
		{
			queue = new Queue<People>();
			queue.Enqueue(new People { name = "Pol" });
			queue.Enqueue(new People { name = "Alise" });
			queue.Enqueue(new People { name = "Summer" });
			queue.Enqueue(new People { name = "Jack" });
			queue.Enqueue(new People { name = "Rick" });
			queue.Enqueue(new People { name = "Morty" });

		}
	}
}



