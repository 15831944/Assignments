using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class InputConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tbConvert = parameter as TextBox;
            string ConvertType = tbConvert.Text;
            switch(ConvertType)
            {
                case "string":
                    if (value is string == false)
                    {
                        return "";
                    }
                    break;
                case "double":
                    double temp;
                    if (!Double.TryParse(value.ToString(), out temp))
                    {
                        return "";
                    }
                    break;
                case "float":
                    float temp2;
                    if (!float.TryParse(value.ToString(), out temp2))
                    {
                        return "";
                    }
                    break;
            }
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(value.ToString()))
            {
                return "";
            }
            return value;
        }

        // ConvertBack is not implemented for a OneWay bindings.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
