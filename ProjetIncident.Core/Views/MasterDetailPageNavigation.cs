using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.ViewModel;
using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class MasterDetailPageNavigation : MasterDetailPage
    {

        public MasterDetailPageNavigation()
        {
            InitializeComponent();
            this.BindingContext = new MasterDetailPageNavigationViewModel();
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}

