using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileBMICalculatorApp
{

    public partial class BottomTab : Xamarin.Forms.Shell
    {
        public BottomTab()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.CalculatorView), typeof(Views.CalculatorView));
            Routing.RegisterRoute(nameof(Views.EditDataView), typeof(Views.EditDataView));
            Routing.RegisterRoute(nameof(Views.HistoryView), typeof(Views.HistoryView));
            Routing.RegisterRoute(nameof(Views.OverviewView), typeof(Views.OverviewView));
        }
    }
}