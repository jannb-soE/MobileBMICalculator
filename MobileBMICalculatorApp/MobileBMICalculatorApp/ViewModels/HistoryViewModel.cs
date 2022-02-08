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
    class HistoryViewModel : INotifyPropertyChanged
    {
        public ICommand SelectUser { get; }

        public ICommand ShowAllData { get; }

        #region Eventhandlers

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private string _selUser;
        private List<BMICalculatedData> _datas;

        public string SelectedUser
        {
            set
            {
                _selUser = value;
                NotifyPropertyChanged();
                GetData();
            }
            get
            {
                return _selUser;
            }
        }

        public List<BMICalculatedData> Data
        {
            set
            {
                _datas = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _datas;
            }
        }

        #endregion
        public HistoryViewModel()
        {
            SelectUser = new Command(() => { ShowUserSelection(); });
            ShowAllData = new Command(() => { SelectedUser = null; });
            GetData();
        }


        //Shows the user selection dialog
        private async void ShowUserSelection()
        {
            string choice = await UserDialogs.Instance.ActionSheetAsync("Select user", "Cancel", "Confirm", CancellationToken.None, App.UserDB.GetUsers().ToArray());

            if (choice != "Cancel" && choice != string.Empty)
            {
                SelectedUser = choice;
            }
        }

        //Gets the data for the specified user
        private async void GetData()
        {
            List<BMICalculatedData> tempData = new List<BMICalculatedData>();

            if (String.IsNullOrEmpty(SelectedUser))
            {

                foreach (var data in await App.BmiCalculatedDB.GetBMIs())
                {
                    tempData.Add(data);
                }
            }
            else
            {
                foreach (var data in await App.BmiCalculatedDB.GetBMIForName(SelectedUser))
                {
                    tempData.Add(data);
                }
            }


            Data = tempData;
        }
    }
}
