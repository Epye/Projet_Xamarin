using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjetIncident.Core.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            propertyValues = new Dictionary<string, object>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Dictionary<String, object> propertyValues;

        protected T GetProperty<T>([CallerMemberName] string propertyName = null){
            if(propertyValues.ContainsKey(propertyName))
                return (T)propertyValues[propertyName];
            return default(T);
        }

        protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null){
            if(!EqualityComparer<T>.Default.Equals(GetProperty<T>(propertyName), value)){
                propertyValues[propertyName] = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
