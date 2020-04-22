using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Book
    {
        public string title  {get; set;}
        public string author { get; set; }
    }

    public class Mock
    {
        public static LinkedList<Book> books = new LinkedList<Book>();

        public static void AddBooks()
        {
            books.Add(new Book {author = "Pushkin", title = "CaptainDaughter"});
            books.Add(new Book {author = "Hytler", title = "MeinKampf"});
            books.Add(new Book {author = "Lermontov", title = "Borodino"});
            books.Add(new Book {author = "Rend", title = "Atlant"});
            books.Add(new Book {author = "Taler", title = "BehavioralEconomic"});
        }
    }
}