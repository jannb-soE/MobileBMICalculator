using Acr.UserDialogs;
using MobileBMICalculatorApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileBMICalculatorApp.ViewModels
{
    class OverviewViewModel
    {
        private List<string> _rating;
        public event PropertyChangedEventHandler PropertyChanged;

        public OverviewViewModel()
        {
            Rating = new List<string>()
            {
                "Severely Underweight: \nFrom 0 to 16.9",
                "Slightly Underweight: \nFrom 17 to 18.5",
                "Normal weight: \nFrom 18.5 to 24.9",
                "Overweight: \nFrom 24.9 to 29.9",
                "Obese: \nFrom 29.9 to 34.9",
                "Extremely Obese: \nAbove 35"

            };
        }
        public List<string> Rating
        {
            get { return _rating; }

            set
            {
                _rating = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
