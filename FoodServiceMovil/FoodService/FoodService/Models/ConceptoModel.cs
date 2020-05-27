using System;
using System.Collections.Generic;
using System.Text;

namespace FoodService.Models
{
    public class ConceptoModel
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Uso { get; set; }

        public ConceptoModel(int id, string descripcion, string uso)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Uso = uso;
        }


    }
}
