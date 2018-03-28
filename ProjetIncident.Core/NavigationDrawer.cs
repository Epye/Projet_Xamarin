using System;
using System.Threading.Tasks;
using ProjetIncident.Core.ViewModel;
using ProjetIncident.Core.Views;
using Xamarin.Forms;

namespace ProjetIncident.Core
{
    public class NavigationDrawer
    {
        #region Singleton

        private static NavigationDrawer _currentService = null;
        public static NavigationDrawer GetInstance()
        {
            if (_currentService == null)
            {
                _currentService = new NavigationDrawer();
            }

            return _currentService;
        }

        #endregion

        private Page _menuPage;
        private NavigationDrawer _navigationPage;
        protected NavigationDrawer NavigationPage
        {
            get { return _navigationPage; }
            private set
            {
                if (value != _navigationPage)
                {
                    _navigationPage = value;
                    RootPage.Detail = _navigationPage;
                }
            }
        }
        public MasterDetailPage RootPage { get; }

        public bool MenuIsPresented
        {
            get { return RootPage?.IsPresented ?? false; }
            set { if (RootPage != null) RootPage.IsPresented = value; }
        }

        private NavigationDrawer()
        {
            RootPage = new MasterDetailPage()
            {
                MasterBehavior = MasterBehavior.Popover,
            };

            _menuPage = new MenuNavigation
            {
                BindingContext = new MenuNavigationViewModel()
            };
            RootPage.Master = _menuPage;

            _navigationPage = new NavigationPage(new HomePage())
            {
                BindingContext = new HomePageViewModel()
            };
            RootPage.Detail = NavigationPage;
        }


        public async Task NavigateToRootPage()
        {
            await _navigationPage.PopToRootAsync();
        }
        public void NavigateToWithoutPush(Page page, object viewModel = null)
        {
            if (viewModel != null) page.BindingContext = viewModel;
            NavigationPage = new NavigationPage(page);
            MenuIsPresented = false;
        }
        public async Task NavigateToWithPush(Page page, object viewModel = null)
        {
            if (viewModel != null) page.BindingContext = viewModel;
            await NavigationPage.Navigation.PushAsync(page);
        }

        public static implicit operator Page(NavigationDrawer v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator NavigationDrawer(NavigationPage v)
        {
            throw new NotImplementedException();
        }
    }
    }
}
