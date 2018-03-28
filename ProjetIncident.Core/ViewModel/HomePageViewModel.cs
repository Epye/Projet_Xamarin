using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ProjetIncident.Core.DataAccess;
using ProjetIncident.Core.Model;

namespace ProjetIncident.Core.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Incident> ListIncident {
            get => GetProperty<ObservableCollection<Incident>>();
            set => SetProperty(value); 
        }

        public HomePageViewModel()
        {
            ListIncident = new ObservableCollection<Incident>();
            loadData();



        }

        public async Task loadData(){
            var dbcontext = await IncidentsDBContext.GetCurrent();
            var listItems=dbcontext.Incidents.Where(i => i.Status == Incident.StatusValues.Submitted).ToList();
            for (int i = 0; i < listItems.Count;i++){
                ListIncident.Add(listItems[i]);
            }

        }
    }
}
