using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class BookProvider
    {
        public List<BookViewModel> GetBooks()
        {
            List<BookViewModel> books = new List<BookViewModel>();

            books.Add(new BookViewModel(new Book
            {
                Title = "Book1",
                Authors = new List<Author> { new Author { Name = "Joe" }, new Author { Name = "Phil" } }
            }));

            books.Add(new BookViewModel(new Book
            {
                Title = "Book2",
                Authors = new List<Author> { new Author { Name = "Jane" }, new Author { Name = "Bob" } }
            }));

            return books;
        }
    }
}
