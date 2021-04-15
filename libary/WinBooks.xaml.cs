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
    /// Логика взаимодействия для WinBooks.xaml
    /// </summary>
    public partial class WinBooks : Page
    {
        public WinBooks(MainVM mainVM)
        {
            InitializeComponent();
            DataContext = new VMBooks(mainVM);
        }
    }
}
