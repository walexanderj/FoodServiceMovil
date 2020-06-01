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
    public partial class NovedadPage : ContentPage
    {
        public NovedadPage(NovedadViewModel novedadViewModel)
        {
            InitializeComponent();
            BindingContext = novedadViewModel;
            lb_turnos.IsVisible = false;
            if (lbl_TipoNovedad.Text == "Change") { lb_turnos.IsVisible = true; }
        }


    }
}