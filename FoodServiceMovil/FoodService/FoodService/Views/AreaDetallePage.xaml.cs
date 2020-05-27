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
    public partial class AreaDetallePage : ContentPage
    {
        List<EmpleadoModel> EmpleadosSeleccionados = new List<EmpleadoModel>();
        public AreaDetallePage(AreaPageViewModel areaDetallePageViewModel)
        {
            InitializeComponent();
            BindingContext = areaDetallePageViewModel;
        }

        private void obtenerEmpleadosSeleccionados()
        {
            foreach (EmpleadoModel item in grd_Empleados.ItemsSource)
            {
                if (item.IsChecked == true)
                {
                    EmpleadosSeleccionados.Add(item);
                }
            }
        }
        async private void mn_new_service_Clicked(object sender, EventArgs e)
        {

            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("New",EmpleadosSeleccionados)));
        }



        async private void mn_cancel_service_Clicked(object sender, EventArgs e)
        {
            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("Cancel", EmpleadosSeleccionados)));
        }

        async private void mn_change_service_Clicked(object sender, EventArgs e)
        {
            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("Change", EmpleadosSeleccionados)));
        }

        private void Mn_home_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}