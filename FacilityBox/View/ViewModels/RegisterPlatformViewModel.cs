using FacilityBox.Controller;
using FacilityBox.Model;
using FacilityBox.Model.Helpers;
using ResultMD.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FacilityBox.View.ViewModels
{
    public class RegisterPlatformViewModel : BaseNotifyPropertyChanged
    {
        PlatformService _PlatformService = new PlatformService();
        public RegisterPlatformViewModel()
        {
            ID = _PlatformService.GetMaxID() + 1;
            Platforms = _PlatformService.GetAllPlatforms();
            IsEdit = false;
        }

        #region Properties
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyRaised("ID"); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyRaised("Name"); }
        }

        private decimal _Rate;

        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; OnPropertyRaised("Rate"); }
        }

        private bool _Inactive;

        public bool Inactive
        {
            get { return _Inactive; }
            set { _Inactive = value; OnPropertyRaised("Inactive"); }
        }

        private Platform _SelectedPlatform;

        public Platform SelectedPlatform
        {
            get { return _SelectedPlatform; }
            set { _SelectedPlatform = value; OnPropertyRaised("SelectedPlatform"); }
        }

        private List<Platform> _Platforms;

        public List<Platform> Platforms
        {
            get { return _Platforms; }
            set { _Platforms = value; OnPropertyRaised("Platforms"); }
        }

        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; OnPropertyRaised("IsEdit"); }
        }

        #endregion

        #region Commands

        ICommand _ClearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _ClearCommand ?? (_ClearCommand = new CommandHandler(() => Clear(), true));
            }
        }


        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new CommandHandler(() => Save(), true));
            }
        }
        #endregion


        #region Methods

        public void Clear()
        {
            ID = _PlatformService.GetMaxID() + 1;
            Name = "";
            Rate = 0;
            Inactive = false;
            IsEdit = false;
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Informe o nome da Plataforma!", "Atenção");
                return false;
            }

            if(Rate <= 0)
            {
                MessageBox.Show("Valor da Taxa inválido!", "Atenção");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (!Validation()) return;

            Platform platform = new Platform();

            platform.PlatformID = ID;
            platform.Name = Name;
            platform.Rate = Rate;
            platform.Inactive = Inactive;

            if (!IsEdit)
            {
                //save
                var plat = _PlatformService.GetPlatformByName(platform.Name.Trim());
                if (plat != null)
                {
                    MessageBox.Show($"Já existe uma plataforma com o nome {plat.Name}!", "Atenção");
                    return;
                }

                var id = _PlatformService.CreatePlatform(platform);
            }
            else
            {
                //update
                var id = _PlatformService.UpdatePlatform(platform);
            }

            MessageBox.Show("Operação realizada com SUCESSO!", "Sucesso");
            Platforms = _PlatformService.GetAllPlatforms();
            Clear();
        }

        #endregion



    }
}
