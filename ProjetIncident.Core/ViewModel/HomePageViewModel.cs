using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ProjetIncident.Core.DataAccess;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.Views;
using Xamarin.Forms;

namespace ProjetIncident.Core.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Incident> ListIncident {
            get => GetProperty<ObservableCollection<Incident>>();
            set => SetProperty(value); 
        }

        private Incident _ItemSelected;
        public Incident ItemSelected
        {
            get { return _ItemSelected; }
            set
            {
                _ItemSelected = value;
                var newPage = new Details_Incident(_ItemSelected);
                NavigationDrawer.GetInstance().NavigateToWithPush(newPage, new Details_IncidentViewModel(_ItemSelected));
            }
        }



        public HomePageViewModel()
        {
            ListIncident = new ObservableCollection<Incident>();
            loadData();

        }

        public async Task loadData(){
            ListIncident.Clear();
            var dbcontext = await IncidentsDBContext.GetCurrent();
            var listItems=dbcontext.Incidents.Where(i => i.Status == Incident.StatusValues.Submitted).ToList();
            for (int i = 0; i < listItems.Count;i++){
                ListIncident.Add(listItems[i]);
            }

        }
    }
}
