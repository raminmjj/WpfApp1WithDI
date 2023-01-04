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

namespace WpfApp1WithDI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Func<Page1> Page1Factory { get; }

        public Home(Func<Page1> page1Factory) 
        {
            InitializeComponent();
            this.Page1Factory = page1Factory;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 nextPage = this.Page1Factory.Invoke();
            NavigationService.Navigate(nextPage);
        }
    }
}
