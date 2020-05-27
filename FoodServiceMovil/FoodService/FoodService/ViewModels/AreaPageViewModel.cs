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

        private bool _IsRefreshing;
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                _IsRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }
        public AreaPageViewModel(AreaModel item)
        {
            Item = item;
            Empleados = new ObservableCollection<EmpleadoModel>();
            ListarEmpleados();
        }

        async private void ListarEmpleados()
        {
            IsRefreshing = true;
            Item = await new FoodServiceRepository().GetArea((int)Item.Id);
                        
            var empleados = new  ObservableCollection<EmpleadoModel>(Item.Empleados);
            foreach (var itemEmpleado in empleados)
            {
                Empleados.Add(itemEmpleado);
            }
            IsRefreshing = false;
        }
    }
}
