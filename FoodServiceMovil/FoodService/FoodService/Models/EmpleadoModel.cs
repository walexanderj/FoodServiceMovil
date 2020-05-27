﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodService.Models
{
    public class EmpleadoModel
    {
        public long Id { get; set; }
        public long IdArea { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public bool EsAdministrador { get; set; }
        public bool EsSuperUsuario { get; set; }
        public bool Activo { get; set; }
        public bool EsAdministrativo { get; set; }
        public string UserName { get; set; }
        public string TipoContrato { get; set; }
        public bool AutoProgramar { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRetiro { get; set; }
        public string Telefono { get; set; }
        public List<ProgramacionModel> Programacion { get; set; }
        public List<NovedadModel> Novedades { get; set; }

        public bool IsChecked { get; set; }
    }
}
