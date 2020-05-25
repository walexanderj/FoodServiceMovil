using FoodService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodService.ViewModels
{
    public class LoginViewModel
    {
        public LoginModel Item = new LoginModel();
        LoginViewModel(LoginModel item)
        {
            this.Item = item;
        }
    }
}
