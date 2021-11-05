using FacilityBox.Model.Helpers;
using FacilityBox.View.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterCategory.xaml
    /// </summary>
    public partial class RegisterPlatform : Window
    {
        public RegisterPlatform(RegisterPlatformViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
            Load();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
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

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = (DataContext as RegisterPlatformViewModel);
            a.IsEdit = true;
            a.ID = a.SelectedPlatform.PlatformID;
            a.Name = a.SelectedPlatform.Name;
            a.Rate = a.SelectedPlatform.Rate;
            a.Inactive = a.SelectedPlatform.Inactive;

            Dispatcher.BeginInvoke((Action)(() => tcPlatforms.SelectedIndex = 1));

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var t = (TextBox)sender;
            e.Handled = Regex.IsMatch(t.Text, "[^0-9.,]");
        }

    }
    }
