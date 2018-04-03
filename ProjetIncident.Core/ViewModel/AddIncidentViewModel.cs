using System;
using System.Collections.Generic;
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


        public AddIncidentViewModel()
        {
            Valid = new Command(async () =>
            {
                List<Photo> photos = new List<Photo>();
                photos.Add(new Photo("trntrdntrzn"));

                var incident = new Incident(textDescription, 0.0, 0.0, 0.0, Incident.StatusValues.Submitted, DateTime.Now, new Category("test", null), new User("LANNIER", "Johan", "johan@lannier.fr", "encryptedMDP"), photos);
                var dbcontext = await IncidentsDBContext.GetCurrent();
                await dbcontext.AddAsync(incident);
                await dbcontext.SaveChangesAsync();
                await NavigationDrawer.GetInstance().NavigateToRootPage();
            });
        }

    }
}
