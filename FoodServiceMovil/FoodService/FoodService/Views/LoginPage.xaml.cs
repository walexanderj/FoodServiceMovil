using FoodService.Models;
using FoodService.Repository;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            Login();
        }
        async private void Login()
        {
            LoginModel login = new LoginModel();
            login.UserName = txt_email.Text;
            login.PassWord = txt_password.Text;
            var usuario = (UsuarioModel)await new FoodServiceRepository().GetUsuario(login);
            if (usuario != null)
            {
                VariablesGlobales.USER = usuario;
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                //await DisplayAlert("Campos incorrectos", "usuario o password incorrecto", "Aceptar");
            }
        }
    }
}