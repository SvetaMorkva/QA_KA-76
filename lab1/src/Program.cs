using System;
using lab1;
// namespace lab1
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var linked_list = new DoublyLinkedList(1);
            linked_list.Add(2);
            Node curr = linked_list.GetCurrent(1);
            Console.WriteLine(curr.getKey());
            // var node = new Node(1);
            // Console.WriteLine(node.getKey());
            // Console.WriteLine(node.hasNext());
            // Console.WriteLine(node.hasPrev());
            
            // node.print();
            // linked_list.print();

            // linked_list.Print();
            // var vers_comp = new VersionComparator();

            // Task 1
            // linked_list.GetCurrent();
            // linked_list.GetPrevious();
            // linked_list.GetNext();
            // linked_list.Add();

            // Task 2
            // vers_comp.CompareVersions("Pavlo", "Pyvovar");
            // Console.WriteLine("Hello World!");
        }
    }
}