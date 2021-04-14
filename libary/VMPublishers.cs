using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace libary
{
    public class VMPublishers : INotifyPropertyChanged
    {
        Db db;
        public string Name { get; set; }
        public string Address { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }
        private Publisher selectedPublisher;
        public CustomCommand AddPublisher { get; set; }
        public CustomCommand SavePublishers { get; set; }

        public VMPublishers()
        {
            db = Db.GetDb();
            AddPublisher = new CustomCommand(() =>
                {
                    var publisher = new Publisher { Name = "Название", Address = "Адрес" };
                    db.Publishers.Add(publisher);
                    SelectedPublisher = publisher;
                    LoadPublisher();
                });

            SavePublishers = new CustomCommand(() =>
            {
                try
                {
                    db.SaveChanges();
                    LoadPublisher();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Publisher SelectedPublisher
        {
            get => selectedPublisher;
            set { selectedPublisher = value; SignalChanged(); }
        }

        private void LoadPublisher()
        {
            Publishers = new ObservableCollection<Publisher>(db.Publishers);
            SignalChanged("Publishers");
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
