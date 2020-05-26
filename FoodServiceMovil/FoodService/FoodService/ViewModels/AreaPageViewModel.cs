using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodService.ViewModels
{
    public class AreaPageViewModel:BaseViewModel
    {
        public AreaModel Item { get; set; }
        public ObservableCollection<EmpleadoModel> Empleados { get; set; }

        public AreaPageViewModel(AreaModel item)
        {
            Item = item;
            ListarEmpleados();
        }

        async private void ListarEmpleados()
        {
            Item = await new FoodServiceRepository().GetArea((int)Item.Id);
            foreach (var itemEmpleado in Item.Empleados)
            {
                Empleados.Add(itemEmpleado);
            }
        }
    }
}
