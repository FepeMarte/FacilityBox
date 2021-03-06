using FacilityBox.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FacilityBox.Model
{
    public class Utils: BaseNotifyPropertyChanged
    {
        public static string ConnectionString { get; set; }
        public static Brush PrimaryColor { get; set; }
        public static Brush SecondaryColor { get; set; }

        public static void Initialize()
        {
            ConnectionString = @"Data Source=(localDb);Initial Catalog=Facility;Integrated Security=True";
            
            Config config = ConfigService.GetConfigByID(1);
            
            PrimaryColor = (Brush)new BrushConverter().ConvertFrom(config.PrimaryColor);
            SecondaryColor = (Brush)new BrushConverter().ConvertFrom(config.SecondaryColor);
        }




    }
}
