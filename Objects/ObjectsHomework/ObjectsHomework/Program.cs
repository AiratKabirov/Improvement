using System;
using System.Collections.Generic;

namespace ObjectsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionaryOfBooks = new Dictionary<Book, string>();
            Book bookToCheck = null;

            for (int i = 0; i < 20; i++)
            {
                var book = new Book(Guid.NewGuid());
                book.Name = i.ToString();

                if (i == 10)
                {
                    bookToCheck = book;
                }

                dictionaryOfBooks.Add(book, book.Name);
            }

            Console.WriteLine("Book to check: " + bookToCheck.Name);
            Console.WriteLine("Book from dictionary: " + dictionaryOfBooks[bookToCheck]);
        }
    }
}
