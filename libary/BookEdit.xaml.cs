using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace libary
{
    /// <summary>
    /// Логика взаимодействия для BookEdit.xaml
    /// </summary>
    public partial class BookEdit : Page
    {
        public BookEdit(Book book)
        {
            InitializeComponent();
            DataContext = new VMBooksEdit(book);
        }
        public BookEdit()
        {
            InitializeComponent();
            DataContext = new VMBooksEdit();
        }
    }
}
