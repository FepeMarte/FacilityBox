using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FacilityBox.Controller;
using FacilityBox.Model;
using FacilityBox.Model.Helpers;
using ResultMD.Helpers;

namespace FacilityBox.View.ViewModels
{
    public class ConfigControlViewModel: BaseNotifyPropertyChanged
    {
        ConfigService configService = new ConfigService();
        public ConfigControlViewModel()
        {
            FillListThemes();
            FillForm();
        }

        #region Properties

        private List<Theme> _Themes;

        public List<Theme> Themes
        {
            get { return _Themes; }
            set { _Themes = value; OnPropertyRaised("Themes"); }
        }

        private Theme _SelectedTheme;

        public Theme SelectedTheme
        {
            get { return _SelectedTheme; }
            set { _SelectedTheme = value; OnPropertyRaised("SelectedTheme"); }
        }


        #endregion

        #region Commands

        ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new CommandHandler(() => Close(), true));
            }
        }

        ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new CommandHandler(() => Save(), true));
            }
        }
        #endregion

        #region Methods

        public void FillListThemes()
        {
            Themes = new List<Theme>();

            var color1 = new Theme();
            
            color1.Name = "Laranja";
            color1.PrimaryColor = "#ff6100";
            color1.SecondaryColor = "#ffcfb2";

            Themes.Add(color1);

            var color2 = new Theme();

            color2.Name = "Verde";
            color2.PrimaryColor = "#35b546";
            color2.SecondaryColor = "#a9ebb2";

            Themes.Add(color2);

            var color3 = new Theme();

            color3.Name = "Azul Claro";
            color3.PrimaryColor = "#03b6fc";
            color3.SecondaryColor = "#b8e2f5";

            Themes.Add(color3);

            var color4 = new Theme();

            color4.Name = "Azul Marinho";
            color4.PrimaryColor = "#0033ff";
            color4.SecondaryColor = "#a2b4fc";

            Themes.Add(color4);

            var color5 = new Theme();

            color5.Name = "Vermelho";
            color5.PrimaryColor = "#ff0000";
            color5.SecondaryColor = "#f59595";

            Themes.Add(color5);

            var color6 = new Theme();

            color6.Name = "Amarelo";
            color6.PrimaryColor = "#d2ed05";
            color6.SecondaryColor = "#e3f55f";

            Themes.Add(color6);

            var color7 = new Theme();

            color7.Name = "Lilás";
            color7.PrimaryColor = "#6d05f5";
            color7.SecondaryColor = "#c49bfa";

            Themes.Add(color7);

            var color8 = new Theme();

            color8.Name = "Preto";
            color8.PrimaryColor = "#262626";
            color8.SecondaryColor = "#9e9e9e";

            Themes.Add(color8);

        }

        public bool Validation()
        {
            return false;
        }
        public void Save()
        {
            var config = new Config();

            config.PrimaryColor = SelectedTheme.PrimaryColor;
            config.SecondaryColor = SelectedTheme.SecondaryColor;

            try
            {
                var id = configService.UpdateConfig(config);
                MessageBox.Show("Operação realizada com sucesso.", "Sucesso");
                Utils.Initialize();
                AlterColor();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
         
        }

        public void Close()
        {
            foreach (var item in System.Windows.Application.Current.Windows)
            {
                var window = System.Windows.Application.Current.Windows.OfType<ConfigControl>().FirstOrDefault();
                if (window != null)
                {
                    window.Close();
                }
            }
        }

        public void AlterColor()
        {
            foreach (var item in System.Windows.Application.Current.Windows)
            {
                var window = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (window != null)
                {
                    window.Load();
                }
            }
        }

        public void FillForm()
        {
            var config = ConfigService.GetConfigByID(1);
            SelectedTheme = Themes.FirstOrDefault(t => t.PrimaryColor == config.PrimaryColor);
        }

        #endregion
    }
}
