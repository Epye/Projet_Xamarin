using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ProjetIncident.Core.Views
{
    public partial class ConnectionPage : ContentPage
    {
        public ConnectionPage()
        {
            InitializeComponent();
        }

        void Connect(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MasterDetailPageNavigation();
        }
    }
}
