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
    public partial class EmpleadosPage : ContentPage
    {
        List<EmpleadoModel> EmpleadosSeleccionados = new List<EmpleadoModel>();
        public EmpleadosPage()
        {
            InitializeComponent();
            BindingContext = new EmpleadosPageViewModel();
        }

        private void obtenerEmpleadosSeleccionados()
        {
            EmpleadosSeleccionados.Clear();
            foreach (EmpleadoModel item in grd_Empleados.ItemsSource)
            {
                if (item.IsChecked == true)
                {
                    EmpleadosSeleccionados.Add(item);
                    //item.IsChecked = false;
                }
            }
        }
        //private void QuitarSeleccion()
        //{

        //    foreach (EmpleadoModel item in grd_Empleados.ItemsSource)
        //    {
        //        item.IsChecked = false;
        //    }
        //}

        async private void grd_Empleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as EmpleadoModel;

            await Navigation.PushAsync(new ProgramacionEmpleadoPage(new ProgramacionEmpleadoPageViewModel(selectedItem)));
        }

        private void mn_home_Clicked(object sender, EventArgs e)
        {
            //QuitarSeleccion();
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        async private void mn_new_service_Clicked(object sender, EventArgs e)
        {
            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("New", EmpleadosSeleccionados)));

            //QuitarSeleccion();
        }

        async private void mn_cancel_service_Clicked(object sender, EventArgs e)
        {
            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("Cancel", EmpleadosSeleccionados)));

            //QuitarSeleccion();
        }

        async private void mn_change_service_Clicked(object sender, EventArgs e)
        {
            obtenerEmpleadosSeleccionados();

            await Navigation.PushAsync(new NovedadPage(new NovedadViewModel("Change", EmpleadosSeleccionados)));

            //QuitarSeleccion();
        }
        
    }
}