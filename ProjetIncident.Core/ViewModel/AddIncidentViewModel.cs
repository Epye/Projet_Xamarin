using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Plugin.Media;
using ProjetIncident.Core.Commands;
using ProjetIncident.Core.DataAccess;
using ProjetIncident.Core.Model;
using ProjetIncident.Core.ViewModel;
using ProjetIncident.Core.Views;
using Xamarin.Forms;

namespace ProjetIncident.Core.ViewModel
{
    public class AddIncidentViewModel : BaseViewModel
    {
        List<Photo> photos = new List<Photo>();

        public DelegateCommand Valid{
            get => new DelegateCommand(async () =>
            {
                var incident = new Incident(textDescription, 0.0, 0.0, 0.0, Incident.StatusValues.Submitted, DateTime.Now, new Category("test", null), new User("LANNIER", "Johan", "johan@lannier.fr", "encryptedMDP"), photos);
                var dbcontext = await IncidentsDBContext.GetCurrent();
                await dbcontext.AddAsync(incident);

                //fonctionne pas ? pas de photos dans la bd ?
                for (int i = 0; i < photos.Count; i++){
                    await dbcontext.AddAsync(photos[i]);
                }
                
                await dbcontext.SaveChangesAsync();

                //ajouter catégorie dans BD

                await NavigationDrawer.GetInstance().PopAsync();
            });
        }

        public DelegateCommand TakePhoto{
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
                    photos.Add(new Photo(imageString));
                    Photos.Add(imageString);
                }
            });
        }


        public String textDescription { get; set; }
        public ObservableCollection<String> Photos{
            get => GetProperty<ObservableCollection<String>>();
            set => SetProperty(value); 
        }


        public AddIncidentViewModel()
        {
            Photos = new ObservableCollection<string>();

        }

    }
}
