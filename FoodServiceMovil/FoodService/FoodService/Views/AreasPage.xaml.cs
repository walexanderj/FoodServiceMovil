using FoodService.Models;
using FoodService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreasPage : ContentPage
    {
        public AreasPage()
        {
            InitializeComponent();
            BindingContext =new  AreasViewModel();
        }

        async private void grd_Areas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (AreaModel)e.SelectedItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new AreaDetallePage(new AreaPageViewModel(item)));
            grd_Areas.SelectedItem = null;
        }

    }
}