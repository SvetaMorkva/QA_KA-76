using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khylenko_lab1
{
    public class Book
    {
        public string author { get; set; }
        public string name { get; set; }

        public string String()
        {
            return string.Format("Author: {0}, book: {1}", author, name);
        }

    }

    public class Mock
    {

        public static DoublyLinkedList<Book> doublyLinkedList = new DoublyLinkedList<Book>();
        public static void AddBooks()
        {

            doublyLinkedList.Add(new Book { author = "Thomas Mann", name = "The Magic Mountain" });
            doublyLinkedList.Add(new Book { author = "Irvine Welsh", name = "Trainspotting" });
            doublyLinkedList.Add(new Book { author = "James Joyce", name = "Ulysses" });
            doublyLinkedList.Add(new Book { author = "Serhiy Zhadan", name = "Anarchy in the UKR" });
            doublyLinkedList.Add(new Book { author = "Jack Kerouac", name = "On the Road" });
            doublyLinkedList.Add(new Book { author = "Jean-Paul Sartre", name = "Nausea" });
        }
    }
}
