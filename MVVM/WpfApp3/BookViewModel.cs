using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book book;
        public Book Book
        {
            get
            {
                return book;
            }
        }

        public string Title
        {
            get
            {
                return Book.Title;
            }
            set
            {
                Book.Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public BookViewModel(Book book)
        {
            this.book = book;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
