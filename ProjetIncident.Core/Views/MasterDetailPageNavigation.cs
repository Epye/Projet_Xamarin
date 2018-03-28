using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetIncident.Core.Model;
using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class MasterDetailPageNavigation : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MasterDetailPageNavigation()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            var page1 = new MasterPageItem() { Title = "Accueil", IconSource = "icon.png", TargetType = typeof(HomePage) };
            var page2 = new MasterPageItem() { Title = "Paramètres", IconSource = "icon.png", TargetType = typeof(HomePage) };
            var page3 = new MasterPageItem() { Title = "Se déconnecter", IconSource = "icon.png", TargetType = typeof(HomePage) };
            // Adding menu items to menuList

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
            navigationDrawerList.ItemsSource = menuList;
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}

