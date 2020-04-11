using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Main
    {
        public static List<Employee> employees = new List<Employee>();
        public static void AddEmployees()
        {
            employees.Add(new Employee() { Company = "Alfreds Futterkiste", Contact = "Maria Anders", Country = "Germany" });
            employees.Add(new Employee() { Company = "Centro commercial Moctezuma", Contact = "Francisco Chang", Country = "Mexico" });
            employees.Add(new Employee() { Company = "Ernst Handel", Contact = "Roland Mendel", Country = "Austria" });
            employees.Add(new Employee() { Company = "Island Trading", Contact = "Helen Bennett", Country = "UK" });
            employees.Add(new Employee() { Company = "Laughing Bacchus Winecellars", Contact = "Yoshi Tannamuri", Country = "Canada" });
            employees.Add(new Employee() { Company = "Magazine Alimentari Riuniti", Contact = "Giovanni Rovelli", Country = "Italy" });
            employees.Add(new Employee() { Company = "Island Trading", Contact = "Maria Mendel", Country = "USA" });
        }
    }
}
