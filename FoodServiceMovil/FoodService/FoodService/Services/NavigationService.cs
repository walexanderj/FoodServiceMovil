using FoodService.Interfeces;
using FoodService.Services;
using FoodService.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(NavigationService))]
namespace FoodService.Services
{
    class NavigationService : INavigationService
    {

        //public void NavigateToAreaPage()
        //{
        //    //var currentPage = GetCurrentPage();

        //    //currentPage.Navigation.PushAsync(new AreaPage());
        //}

        public void NavigateToDashboard()
        {

            var currentPage = GetCurrentPage();

            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        public void NavigateToLogout()
        {
            var currentPage = GetCurrentPage();
            App.Current.MainPage = new NavigationPage(new HomePage());
            //Application.Current.MainPage = new LoginPage();
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            return currentPage;
        }
    }
}
