using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Model
{
    public abstract class BaseNotifyPropertyChanged: INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private event PropertyChangedEventHandler propertyChanged;
        protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<TProp>(
    ref TProp currentValue,
    TProp newValue,
    [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(currentValue, newValue))
            {
                //this.ThrowIfDisposed();

                this.OnPropertyChanging(propertyName);
                currentValue = newValue;
                this.OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            //Debug.Assert(
            //    string.IsNullOrEmpty(propertyName) ||
            //    (this.GetType().GetProperty(propertyName) != null),
            //    "Check that the property name exists for this instance.");

            //PropertyChangingEventHandler eventHandler = this.PropertyChanging;

            //if (eventHandler != null)
            //{
            //    eventHandler(this, new PropertyChangingEventArgs(propertyName));
            //}
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Debug.Assert(
            //    string.IsNullOrEmpty(propertyName) ||
            //    (this.GetType().GetProperty(propertyName) != null),
            //    "Check that the property name exists for this instance.");

            this.propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
