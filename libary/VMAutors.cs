using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace libary
{
    public class VMAutors : INotifyPropertyChanged
    {
        Db db;
        public ObservableCollection<Author> Autors { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public CustomCommand AddAutor { get; set; }
        public CustomCommand SaveAutors { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private Author selectedAutor;
        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set { selectedBook = value; SignalChanged(); }
        }
        public Author SelectedAutor
        {
            get => selectedAutor;
            set { selectedAutor = value; SignalChanged(); }
        }

        public VMAutors()
        {
            db = Db.GetDb();
            AddAutor = new CustomCommand(() =>
            {
                var autor = new Author { FirstName = "Имя", LastName = "Фамилия" };
                db.Authors.Add(autor);
                SelectedAutor = autor;
                LoadAutors();
            });
            SaveAutors = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadAutors();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

            void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void LoadAutors()
        {
            Autors = new ObservableCollection<Author>(db.Authors);
            SignalChanged("Autors");
        }
    }
}

