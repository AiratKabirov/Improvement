using System;

namespace ObjectsHomework
{
    public class Book
    {
        public readonly Guid Id;

        public string Name { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int NumberOfPages { get; set; }

        public Book(Guid id)
        {
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;

            if (book == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return this.Id == book.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
