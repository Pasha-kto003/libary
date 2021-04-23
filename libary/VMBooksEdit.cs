using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace libary
{
    public class VMBooksEdit : INotifyPropertyChanged
    {

        Db db;
        private Book selectedBook = new Book { Genres = new List<Genre>(), Authors = new List<Author>() };
        private Author selectedAuthor;
        private Genre selectedGenre;
        private readonly MainVM mainVM;
        public Page CurrentPage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                SignalChanged();
            }
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public ObservableCollection<Genre> SelectedBookGenres
        {
            get => new ObservableCollection<Genre>(SelectedBook.Genres);
        }
        public ObservableCollection<Author> SelectedBookAuthors
        {
            get => new ObservableCollection<Author>(SelectedBook.Authors);
        }

        public List<Publisher> Publishers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }

        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                selectedAuthor = value;
                SignalChanged();
            }
        }
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                SignalChanged();
            }
        }

        public CustomCommand AddGenre { get; set; }
        public CustomCommand RemoveGenre { get; set; }
        public CustomCommand AddAuthor { get; set; }
        public CustomCommand RemoveAuthor { get; set; }

        public CustomCommand OpenListBooks { get; set; }
        public CustomCommand SaveSelectedBook { get; set; }
        public VMBooksEdit()
        {
            db = Db.GetDb();

            Publishers = new List<Publisher>(db.Publishers);
            Genres = new List<Genre>(db.Genres);
            Authors = new List<Author>(db.Authors);

            OpenListBooks = new CustomCommand(() => { CurrentPage = new WinBooks(mainVM); });
            AddGenre = new CustomCommand(() =>
            {
                SelectedBook.Genres.Add(SelectedGenre);
                SignalChanged("SelectedBookGenres");
            });
            RemoveGenre = new CustomCommand(() =>
            {
                SelectedBook.Genres.Remove(SelectedGenre);
                SignalChanged("SelectedBookGenres");
            });

            AddAuthor = new CustomCommand(() =>
            {
                SelectedBook.Authors.Add(SelectedAuthor);
                SignalChanged("SelectedBookAuthors");
            });
            RemoveAuthor = new CustomCommand(() =>
            {
                SelectedBook.Authors.Remove(SelectedAuthor);
                SignalChanged("SelectedBookAuthors");
            });

            SaveSelectedBook = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        public VMBooksEdit(Book book):this()
        {
           selectedBook = book;
        }
    }
}
