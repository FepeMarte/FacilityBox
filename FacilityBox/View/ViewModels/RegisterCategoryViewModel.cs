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
            Categories = _CategoryService.GetAllCategories();
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



        private List<Category> _Categories;

        public List<Category> Categories
        {
            get { return _Categories; }
            set { _Categories = value; OnPropertyRaised("Categories"); }
        }

        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; OnPropertyRaised("IsEdit"); }
        }


        private Category _SelectedCategory;

        public Category SelectedCategory
        {
            get { return _SelectedCategory; }
            set { _SelectedCategory = value; OnPropertyRaised("SelectedCategory"); }
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
            IsEdit = false;
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

            var cat = _CategoryService.GetCategoryByName(category.Name.Trim());
            if(cat != null)
            {
                MessageBox.Show($"Já existe uma categoria com o nome {cat.Name}!", "Atenção");
                return;
            }
           
            var id = _CategoryService.CreateCategory(category);

            MessageBox.Show("Operação realizada com SUCESSO!", "Sucesso");
            Categories = _CategoryService.GetAllCategories();
            Clear();
        }

        #endregion

    }
}
