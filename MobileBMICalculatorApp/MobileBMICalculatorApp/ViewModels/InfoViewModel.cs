using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileBMICalculatorApp.ViewModels
{


    class InfoViewModel
    {

        public ICommand StartBMI { get; }

        public InfoViewModel()
        {
            StartBMI = new Command(() => { Application.Current.MainPage = new BottomTab(); });
        }
    }
}
