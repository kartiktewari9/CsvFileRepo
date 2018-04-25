using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileProject.Common.Objects.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            Customers = new List<CustomerViewModel>();
        }
        public List<CustomerViewModel> Customers { get; set; }
    }
}
