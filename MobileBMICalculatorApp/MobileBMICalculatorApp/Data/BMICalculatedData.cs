using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileBMICalculatorApp.Data
{
    //This is the table "BMICalculatedData"
    public class BMICalculatedData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
    }
}
