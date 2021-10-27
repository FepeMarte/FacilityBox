using FacilityBox.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FacilityBox.Model.Helpers
{
    public class Utils: BaseNotifyPropertyChanged
    {
        public static string ConnectionString { get; set; }
        public static Brush PrimaryColor { get; set; }
        public static Brush SecondaryColor { get; set; }

        public static void Initialize()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            //ConnectionString = @"Data Source=(localhost);Initial Catalog=Facility;Integrated Security=True";
            
            Config config = ConfigService.GetConfigByID(1);
            
            PrimaryColor = (Brush)new BrushConverter().ConvertFrom(config.PrimaryColor);
            SecondaryColor = (Brush)new BrushConverter().ConvertFrom(config.SecondaryColor);
            
        }


    }

	public class YesNoToBooleanConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            if (value is bool)
            {
                if ((bool)value == true)
                    return "SIM";
                else
                    return "NÃO";
            }
            return "NÃO";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            switch (value.ToString().ToLower())
            {
                case "sim":
                    return true;
                case "não":
                    return false;
            }
            return false;
        }
    }
}
