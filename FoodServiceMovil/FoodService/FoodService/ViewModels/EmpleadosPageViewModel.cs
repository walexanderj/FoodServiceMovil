using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodService.ViewModels
{
    class EmpleadosPageViewModel: BaseViewModel
    {
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

        public EmpleadosPageViewModel()
        {
            Empleados = new ObservableCollection<EmpleadoModel>();
            ListarEmpleados();
        }
        async private void ListarEmpleados()
        {
            _IsRefreshing = true;
            FoodServiceRepository foodServiceRepository = new FoodServiceRepository();
            foreach (var item in await new FoodServiceRepository().GetEmpleados())
            {
                Empleados.Add(item);
            }
            IsRefreshing = false;

        }
    }
}
