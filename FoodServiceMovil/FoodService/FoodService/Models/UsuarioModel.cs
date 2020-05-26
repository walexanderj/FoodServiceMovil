﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodService.Models
{
    class UsuarioModel
    {
        public long Id { get; set; }
        public String UserName { get; set; }
        public String UserFullName { get; set; }
        public string Password { get; set; }
        public bool EsAdministrador { get; set; }
        public bool EsSuperUsuario { get; set; }
        public long IdArea { get; set; }
    }
}
