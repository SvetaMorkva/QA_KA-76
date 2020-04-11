using System;

namespace Lab_1
{
    public class Employee
    {
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }

        public string String()
        {
            return string.Format("Company:{0} Contact:{1} Country:{2}", Company, Contact, Country);
        }
    }

    public class Mock
    {
        public static CustomQueue<Employee> employees = new CustomQueue<Employee>();
        public static void AddEmployees()
        {
            employees.Clear();
            employees.Enqueue(new Employee() { Company = "Alfreds Futterkiste", Contact = "Maria Anders", Country = "Germany" });
            employees.Enqueue(new Employee() { Company = "Centro commercial Moctezuma", Contact = "Francisco Chang", Country = "Mexico" });
            employees.Enqueue(new Employee() { Company = "Ernst Handel", Contact = "Roland Mendel", Country = "Austria" });
            employees.Enqueue(new Employee() { Company = "Island Trading", Contact = "Helen Bennett", Country = "UK" });
            employees.Enqueue(new Employee() { Company = "Laughing Bacchus Winecellars", Contact = "Yoshi Tannamuri", Country = "Canada" });
            employees.Enqueue(new Employee() { Company = "Magazine Alimentari Riuniti", Contact = "Giovanni Rovelli", Country = "Italy" });
            employees.Enqueue(new Employee() { Company = "Island Trading", Contact = "Maria Mendel", Country = "USA" });
        }
    }
}
