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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private IPage1ViewModel Page1ViewModel { get; }

        // This constructor also calls the private default constructor
        // (in case this type has multiple constructor overloads. 
        // Otherwise, move the private default constructor code to this constructor).
        public Page1(IPage1ViewModel page1ViewModel) : this()
        {
            this.DataContext = this.Page1ViewModel;
            this.Page1ViewModel = page1ViewModel;
            Initialize();
        }

        private Page1() => InitializeComponent();
        
        private void Initialize()
        {
            this.Page1ViewModel.GetTitle();
        }
    }
}
