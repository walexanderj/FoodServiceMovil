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
    public partial class ProgramacionEmpleadoPage : ContentPage
    {
        public ProgramacionEmpleadoPage(ProgramacionEmpleadoPageViewModel programacionEmpleadoPageViewModel)
        {
            InitializeComponent();
            BindingContext = programacionEmpleadoPageViewModel;
        }

        private void grd_Empleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}