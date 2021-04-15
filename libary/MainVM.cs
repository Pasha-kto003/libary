using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace libary
{
    public class MainVM : INotifyPropertyChanged
    {
        Db db;
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set { currentPage = value; SignalChanged("CurrentPage"); }
        }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }

        public CustomCommand OpenAutors { get; set; }
        public CustomCommand OpenBooks { get; set; }
        public CustomCommand OpenPublishers { get; set; }
        public CustomCommand OpenGenres { get; set; }
        public CustomCommand OpenBooksEdit { get; set; }

        public MainVM()
        {
            db = Db.GetDb();
            Genres = new ObservableCollection<Genre>(db.Genres);
            OpenAutors = new CustomCommand(() => { CurrentPage = new WinAutors();  });
            OpenBooks = new CustomCommand(() => { CurrentPage = new WinBooks(this); });
            OpenPublishers = new CustomCommand(() => { CurrentPage = new WinPublishers(); });
            OpenGenres = new CustomCommand(() => { CurrentPage = new WinGenre(); });
            OpenBooksEdit = new CustomCommand(() => { CurrentPage = new BookEdit(); });
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
