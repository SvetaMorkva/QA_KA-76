using System;
using lab1;
// namespace lab1
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var linked_list = new DoublyLinkedList();
            var vers_comp = new VersionComparator();

            // Task 1
            linked_list.GetCurrent();
            linked_list.GetPrevious();
            linked_list.GetNext();
            linked_list.Add();

            // Task 2
            vers_comp.CompareVersions("Pavlo", "Pyvovar");
            // Console.WriteLine("Hello World!");
        }
    }
}