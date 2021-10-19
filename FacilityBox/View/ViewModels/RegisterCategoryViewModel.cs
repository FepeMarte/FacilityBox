using FacilityBox.Controller;
using FacilityBox.Model;
using FacilityBox.Model.Helpers;
using ResultMD.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FacilityBox.View.ViewModels
{
    public class RegisterCategoryViewModel: BaseNotifyPropertyChanged
    {
        ConfigService config = new ConfigService(); 
        public RegisterCategoryViewModel()
        {
            ID = config.GetMaxID() + 1;
            Inactive = true;
        }

        #region Properties
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }

        }

        private bool _Inactive;

        public bool Inactive
        {
            get { return _Inactive; }
            set { SetProperty(ref _Inactive, value); }
        }


        #endregion

        #region Commands
        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new CommandHandler(() => Save(), true));
            }
        }

        ICommand _ClearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _ClearCommand ?? (_ClearCommand = new CommandHandler(() => Clear(), true));
            }
        }


        #endregion

        #region Methods

        public void Clear()
        {
            ID = config.GetMaxID() + 1;
            Name = "";
            Inactive = false;
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Informe o nome da Categoria!", "Atenção");
                return false;
            }

            return true;
        }

        public void Save()
        {
            if (!Validation())
            {
                return;
            }

            MessageBox.Show("Operação realizada com SUCESSO!", "Sucesso");
            Clear();
        }

        #endregion

    }
}
