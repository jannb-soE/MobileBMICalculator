using Acr.UserDialogs;
using MobileBMICalculatorApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileBMICalculatorApp.ViewModels
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        public ICommand Calculate { get; }
        public ICommand ClearValues { get; }
        public ICommand SaveValue { get; }


        private readonly BMIOverviewTable BMIServ = new BMIOverviewTable();

        #region Eventhandlers
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private double _height;
        private double _weight;
        private double _calculatedBmi;
        private string _bmiInfo;

        public double Height
        {
            set
            {
                _height = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _height;
            }
        }

        public double Weight
        {
            set
            {
                _weight = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _weight;
            }
        }

        public double CalculatedBMI
        {
            set
            {
                _calculatedBmi = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _calculatedBmi;
            }
        }

        public string BmiInfo
        {
            set
            {
                _bmiInfo = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _bmiInfo;
            }
        }

        #endregion

        public CalculatorViewModel()
        {
            Calculate = new Command(() => { CalculatedBMI = CalculateValues(Height, Weight); BmiInfo = BMIServ.GetBMIOvervie(CalculatedBMI); });
            ClearValues = new Command(() => { Height = 0; Weight = 0; CalculatedBMI = 0; BmiInfo = ""; });
            SaveValue = new Command(() => { SavecalCulatedResult(); });
        }

        //Saves the result to the DB
        private async void SavecalCulatedResult()
        {
            string choice = await UserDialogs.Instance.ActionSheetAsync("Select user.", "Cancel", "Confirm", CancellationToken.None, App.UserDB.GetUsers().ToArray());

            if (choice != "Cancel" && CalculatedBMI != 0 && CalculatedBMI != double.NaN)
            {
                await App.BmiCalculatedDB.SaveNewRecord(new Data.BMICalculatedData() { Name = choice, Height = Height, Weight = Weight, BMI = CalculatedBMI });
                UserDialogs.Instance.Alert("Successfully saved`!", "BMI result saved");
            }
        }

        //Calculates the BMI value
        private double CalculateValues(double height, double weight)
        {
            double heightInSuqareMeters = height / 100;
            heightInSuqareMeters = heightInSuqareMeters * heightInSuqareMeters;

            return Math.Round(weight / heightInSuqareMeters, 2);
        }
    }
}
