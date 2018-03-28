using System;
using System.Collections.ObjectModel;

namespace ProjetIncident.Core.ViewModel
{
    public class ProjetIncidentViewModel : BaseViewModel
    {
        public ProjetIncidentViewModel()
        {
            List = new ObservableCollection<string>();
            List.Add("DELINE LA BEST");
            List.Add("JOHAN LE PLUS BEAU");
        }

        public string MonTexte
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public string Selected
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public ObservableCollection<string> List
        {
            get => GetProperty<ObservableCollection<string>>();
            set => SetProperty(value);
        }
    }
}
