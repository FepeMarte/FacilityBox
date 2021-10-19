using System.Windows;
using System.Threading;
using FacilityBox.View.ViewModels;
using FacilityBox.Controller;
using FacilityBox.Model;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using FacilityBox.View;
using System;
using System.Windows.Media;
using FacilityBox.Model.Helpers;

namespace FacilityBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        ItemService itemService = new ItemService();
        
        public MainWindow()
        {

            InitializeComponent();
            SplashScreenShow();
 
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            Utils.Initialize();
            Load();
        }

        public void SplashScreenShow()
        {

            var vm = new SplashScreenViewModel();
            var dialog = new FacilityBox.View.SplashScreen(vm);

            dialog.Show();

            Thread.Sleep(5000);

            dialog.Close();
        }

        public void Load()
        {
            this.Resources["primaryColor"] = (Utils.PrimaryColor);
            this.Resources["secondaryColor"] = (Utils.SecondaryColor);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var aux = MessageBox.Show("Deseja realmente ENCERRAR o sistema?", "Atenção", MessageBoxButton.YesNo);
            if (aux == MessageBoxResult.Yes)
            {
                Window parentwin = Window.GetWindow(this);
                parentwin.Close();
            }
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            var vm = new RegisterCategoryViewModel();
            var dialog = new RegisterCategory(vm);
            dialog.Owner = this;
            var r = dialog.ShowDialog();

        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            var vm = new ConfigControlViewModel();
            var dialog = new ConfigControl(vm);
            var r = dialog.ShowDialog();
        }
    }
}
