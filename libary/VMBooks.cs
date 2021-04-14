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
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public DateTime PublishDate { get; set; }
        private Author selectedAutor;
        private Book selectedBook;
       
        public Author SelectedAutor 
        {
            get => selectedAutor;
            set { selectedAutor = value; SignalChanged(); }
        }

        private Genre selectedGenre;

        public event PropertyChangedEventHandler PropertyChanged;

        public Genre SelectedGenre { get => selectedGenre; set { selectedGenre = value; SignalChanged(); } }

        public Book SelectedBook
        {
            get => selectedBook;
            set { selectedBook = value; SignalChanged(); }
        }

        public CustomCommand AddBook { get; set; } 
        public CustomCommand SaveBooks { get; set; } 
       

        public VMBooks()
        {
            db = Db.GetDb();
            LoadBooks();
            Genres = new ObservableCollection<Genre>(db.Genres);
            AddBook = new CustomCommand(() =>
            {
                var book = new Book { Name = "Название" };
                db.Books.Add(book);
                LoadBooks();
                SelectedBook = book;
            });

            SaveBooks = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadBooks();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        public void LoadBooks() 
        {
            Books = new ObservableCollection<Book>(db.Books);
            SignalChanged("Books");
        }
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
