using MobileBMICalculatorApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileBMICalculatorApp
{
    public partial class App : Application
    {
        static UserDatabase userDB;
        static BMICalculatedDatabase bmiCalculatedDB;

        public static UserDatabase UserDB
        {
            get
            {
                if (userDB == null)
                {
                    userDB = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
                }
                return userDB;
            }
        }

        public static BMICalculatedDatabase BmiCalculatedDB
        {
            get
            {
                if (bmiCalculatedDB == null)
                {
                    bmiCalculatedDB = new BMICalculatedDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIs.db3"));
                }
                return bmiCalculatedDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new Views.InfoView();
        }

    }
}
