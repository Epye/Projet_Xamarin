using System;
using System.Collections.Generic;
using ProjetIncident.Core.ViewModel;
using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomePageViewModel();
            this.BindingContext = viewModel;
        }

        async void Redirect_Add(object sender, System.EventArgs e)
        {
            var newPage = new Add_Formulaire();
            await Navigation.PushAsync(newPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.loadData();
        }
    }
}
