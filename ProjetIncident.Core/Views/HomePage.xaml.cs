using System;
using System.Collections.Generic;
using ProjetIncident.Core.ViewModel;
using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Redirect_Add(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new Add_Formulaire();
        }
    }
}
