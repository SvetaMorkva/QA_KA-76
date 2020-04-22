using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Course
    {
        public string title { get; set; }
        public string teacher { get; set; }
        public int credits { get; set; }

        public string Print()
        {
            return string.Format("Course {0} has {1} credits ({3})", title, credits, teacher);
        }
    }

    public class testData
    {
        public static LinkedList<Course> schedule = new LinkedList<Course>();
        public static void AddSchedule()
        {
            schedule.Add(new Course { credits = 2, title = "English", teacher = "Mr. A"});
            schedule.Add(new Course { credits = 4, title = "QA", teacher = "Mrs. B" });
            schedule.Add(new Course { credits = 3, title = "Text Mining", teacher = "Mr. C" });
            schedule.Add(new Course { credits = 4, title = "Machine Learning", teacher = "Mrs. D" });
            schedule.Add(new Course { credits = 5, title = "System Analysis", teacher = "Mr. E" });
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Build is on");
            Console.ReadLine();
        }
    }

}