using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media;
using ProjetIncident.Core.DataAccess;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.ViewModel;
using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class Add_Formulaire : ContentPage
    {
        public Add_Formulaire()
        {
            InitializeComponent();
            this.BindingContext = new AddIncidentViewModel();
        }

        /*async Task Valid(object sender, System.EventArgs e)
        {
            var incident = new Incident(descriptionEditor.Text, 0.0, 0.0, 0.0, Incident.StatusValues.Submitted, DateTime.Now);
            var dbcontext = await IncidentsDBContext.GetCurrent();
            dbcontext.Add(incident);
            dbcontext.SaveChanges();
            dbcontext.Incidents.Where(i => i.Status == Incident.StatusValues.Submitted).ToList();
            Application.Current.MainPage = new MasterDetailPageNavigation();
        }*/

        /*private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                RotateImage=true,
                AllowCropping=true

            });

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }*/
    }

}
