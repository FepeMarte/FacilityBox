using FacilityBox.Model.Helpers;
using FacilityBox.View.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FacilityBox.View
{
    /// <summary>
    /// Interaction logic for ConfigControl.xaml
    /// </summary>
    public partial class ConfigControl : Window
    {
        public ConfigControl(ConfigControlViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Load();
        }
        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window parentwin = Window.GetWindow(this);
            parentwin.Close();
        }


        private void stack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public void Load()
        {
            this.Resources["primaryColor"] = (Utils.PrimaryColor);
            this.Resources["secondaryColor"] = (Utils.SecondaryColor);
        }

        private void btnSave_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.Black;
        }

        private void btnSave_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSave.Foreground = Brushes.White;
        }
    }
}
