using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1WithDI
{
    public class Page1ViewModel : IPage1ViewModel
    {
        public Page1ViewModel()
        {

        }

        public string GetTitle()
        {
            return "Welcome";
        }
    }
}
