using System;
using System.Collections.Generic;
using System.Text;

namespace FoodService.Models
{
    public class TurnoModel
    {
        public long Id { get; set; }
        public int IdPlato { get; set; }
        public string Descripcion { get; set; }
        public string Plato { get; set; }
    }
}
