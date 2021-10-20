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
        CategoryService _CategoryService = new CategoryService(); 
        public RegisterCategoryViewModel()
        {
            ID = _CategoryService.GetMaxID() + 1;
           
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
            set {
                _Name = value;
                OnPropertyRaised("Name");
            }

        }

        private bool _Inactive;

        public bool Inactive
        {
            get { return _Inactive; }
            set {
                _Inactive = value;
                 OnPropertyRaised("Inactive");
                 }
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
            ID = _CategoryService.GetMaxID() + 1;
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

            Category category = new Category();
            category.CategoryID = ID;
            category.Name = Name;
            category.Inactive = Inactive;
           
            var id = _CategoryService.CreateCategory(category);

            MessageBox.Show("Operação realizada com SUCESSO!", "Sucesso");
            Clear();
        }

        #endregion

    }
}
