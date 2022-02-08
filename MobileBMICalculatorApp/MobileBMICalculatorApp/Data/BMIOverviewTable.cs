using System;
using System.Collections.Generic;
using System.Text;

namespace MobileBMICalculatorApp.Data
{
    //This is the lookup-table for the BMI-Calculator page
    public class BMIOverviewTable
    {
        public string GetBMIOvervie(double BMI)
        {

            if (BMI <= 16.9) { return "Severely Underweight"; }
            if (BMI <= 18.5) { return "Slightly Underweight"; }
            if (BMI <= 24.9) { return "Normal weight"; }
            if (BMI <= 29.9) { return "Overweight"; }
            if (BMI <= 34.9) { return "Obese"; }
            if (BMI >= 35) { return "Extremely Obese"; }

            return null;
        }
    }
}
