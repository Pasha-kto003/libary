using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace libary
{
    public class VMGenre : INotifyPropertyChanged
    {
        Db db;
        private Genre selectedGenre;
        public Genre SelectedGenre { get => selectedGenre; set { selectedGenre = value; SignalChanged(); } }
        public ObservableCollection<Genre> Genres { get; set; }
        public CustomCommand AddGenre { get; set; }
        public CustomCommand SaveGenres { get; set; }

        public VMGenre()
        {
            db = Db.GetDb();
            LoadGenres();

            AddGenre = new CustomCommand(() =>
            {
                SelectedGenre = new Genre { Name = "Название" };
                db.Genres.Add(SelectedGenre);
                LoadGenres();
            });

            SaveGenres = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadGenres();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(db.Genres);
            SignalChanged("Genres");
        }


    }
}
