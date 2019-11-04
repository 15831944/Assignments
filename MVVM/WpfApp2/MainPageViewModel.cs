using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class MainPageViewModel : BindableBase
    {
        private List<Book> books;
        public List<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                SetProperty(ref books, value);
            }
        }
        public MainPageViewModel()
        {
            Books = new List<Book>();
            Books.Add(new Book
            {
                Title = "Harry Potter",
                Author = "J. K. Rowling",
                Category = "Young-adult fiction",
                Language = "English"
            });
            Books.Add(new Book
            {
                Title = “Written Lives”,
                Author = “Javier Marias”,
                Category = “Biography”,
                Language = “Spanish”
           });
        }
    }
}
