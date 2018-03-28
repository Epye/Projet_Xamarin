using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ProjetIncident.Core.DataAccess;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.ViewModel;
using ProjetIncident.Core.Views;
using Xamarin.Forms;

namespace ProjetIncident.Core.ViewModel
{
    public class AddIncidentViewModel : BaseViewModel
    {
        public ICommand Valid { get; protected set; }
        public String textDescription { get; set; }

        public ObservableCollection<Category> ListCategory { 
            get => GetProperty<ObservableCollection<Category>>(); 
            set => SetProperty(value); 
        }

        public AddIncidentViewModel()
        {
            Valid = new Command(async () =>
            {
                var incident = new Incident(textDescription, 0.0, 0.0, 0.0, Incident.StatusValues.Submitted, DateTime.Now);
                var dbcontext = await IncidentsDBContext.GetCurrent();
                dbcontext.Add(incident);
                dbcontext.SaveChanges();
                Application.Current.MainPage = new MasterDetailPageNavigation();
            });


            ListCategory = new ObservableCollection<Category>();
            ListCategory.Add(new Category("Dégradation"));
            ListCategory.Add(new Category("Casse"));
            ListCategory.Add(new Category("Accident"));
        }

    }
}
