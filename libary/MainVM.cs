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
        public Page CurrentPage { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }

        public CustomCommand OpenAutors { get; set; }
        public CustomCommand OpenBooks { get; set; }
        public CustomCommand OpenPublishers { get; set; }
        public CustomCommand OpenGenres { get; set; }

        public MainVM()
        {
            db = Db.GetDb();
            Genres = new ObservableCollection<Genre>(db.Genres);
            OpenAutors = new CustomCommand(() => { CurrentPage = new WinAutors(); SignalChanged("CurrentPage"); });
            OpenBooks = new CustomCommand(() => { CurrentPage = new WinBooks(); SignalChanged("CurrentPage"); });
            OpenPublishers = new CustomCommand(() => { CurrentPage = new WinPublishers(); SignalChanged("CurrentPage"); });
            OpenGenres = new CustomCommand(() => { CurrentPage = new WinGenre(); SignalChanged("CurrentPage"); });
            
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
