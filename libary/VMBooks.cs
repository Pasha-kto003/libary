using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace libary
{
    public class VMBooks : INotifyPropertyChanged
    {
        //сделать переход на новую страницу
        Db db;
        private List<Book> books;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Book> Books
        {
            get => books;
            set
            {
                books = value;
                SignalChanged();
            }
        }
        public Book SelectedBook { get; set; }

        public CustomCommand AddBook { get; set; }
        public CustomCommand EditBook { get; set; }

        public VMBooks(MainVM mainVM)
        {
            db = Db.GetDb();
            
            AddBook = new CustomCommand(() =>
            {
                var book = new Book { Name = "Название", Authors = new List<Author>(), Genres = new List<Genre>() };
                db.Books.Add(book);
                mainVM.CurrentPage = new BookEdit(book);
                SelectedBook = book;
            });

            EditBook = new CustomCommand(() =>
            {
                var booklist = new Book();
                mainVM.CurrentPage = new BookEdit(booklist);
                SelectedBook = booklist;
            });
        }
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
