using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.Views;
using Xamarin.Forms;

namespace ProjetIncident.Core.ViewModel
{
    public class MasterDetailPageNavigationViewModel : BaseViewModel
    {
        public ObservableCollection<MasterPageItem> menuList
        {
            get => GetProperty<ObservableCollection<MasterPageItem>>();
            set => SetProperty(value);
        }

        public ListView NavigationDrawerList { get; set; }

        public MasterDetailPageNavigationViewModel()
        {
            menuList = new ObservableCollection<MasterPageItem>();

            menuList.Add(new MasterPageItem() { Title = "Accueil", IconSource = "icon.png", TargetType = typeof(HomePage) });
            menuList.Add(new MasterPageItem() { Title = "Paramètres", IconSource = "icon.png", TargetType = typeof(HomePage) });
            menuList.Add(new MasterPageItem() { Title = "Se déconnecter", IconSource = "icon.png", TargetType = typeof(ConnectionPage) });

            (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }
    }
}
