using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Plugin.Media;
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
        public ObservableCollection<String> Photos{
            get => GetProperty<ObservableCollection<String>>();
            set => SetProperty(value); 
        }

        public DelegateCommand TakePhoto
        {
            get => new DelegateCommand(async () =>
            {
                var imageString = "";
                await CrossMedia.Current.Initialize();
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    RotateImage = true,
                    AllowCropping = true

                });

                if (photo != null)
                {

                    using (var stream = photo.GetStream())
                    {
                        byte[] imageBinary = new byte[stream.Length];
                        stream.Read(imageBinary, 0, (int)stream.Length);
                        imageString = Tools.Convert.BytesToBase64String(imageBinary);
                    }
                    System.IO.File.Delete(photo.Path);
                    Photos.Add(imageString);
                }
            });
        }

        public AddIncidentViewModel()
        {
            Photos = new ObservableCollection<string>();

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
