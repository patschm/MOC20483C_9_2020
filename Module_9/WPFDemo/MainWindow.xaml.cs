using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemo.ViewModels;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var model = new PersonViewModel { Age = 50, Name = "Peter" };
            var main = new DetailViewModel { Person = model };
            main.People.Add(new PersonViewModel { Age = 50, Name = "Peter" });
            main.People.Add(new PersonViewModel { Age = 50, Name = "Peter 4" });
            main.People.Add(new PersonViewModel { Age = 50, Name = "Peter 7" });
            main.People.Add(new PersonViewModel { Age = 50, Name = "Peter 9" });
            DataContext = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((DetailViewModel)DataContext).Person.Name = "Marieke";
        }
    }
}
