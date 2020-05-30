using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodService.ViewModels
{
    class EmpleadosPageViewModel: BaseViewModel
    {
        public string ValorBuscar { get; set; }
        public ICommand BuscarCommand { get; set; }
        public ObservableCollection<EmpleadoModel> EmpleadosFiltro { get; set; }
        public List<EmpleadoModel> Empleados = new List<EmpleadoModel>();
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
            ValorBuscar = "";
            BuscarCommand = new Command(Buscar);
            EmpleadosFiltro = new ObservableCollection<EmpleadoModel>();
            ListarEmpleados();
            //Buscar();
        }

        private void Buscar()
        {
            _IsRefreshing = true;
            EmpleadosFiltro.Clear();
            var emps = Empleados.Where(x => x.Nombre.ToUpper().Contains(ValorBuscar.ToUpper())).OrderBy(o => o.Nombre).ToList();
            // EmpleadosFiltro = new ObservableCollection<EmpleadoModel>(emps);
            foreach (EmpleadoModel emp in emps)
            {
                EmpleadosFiltro.Add(emp);
            }
            ValorBuscar = "";
            _IsRefreshing = false;
            //ListarEmpleados();
        }

        async private void ListarEmpleados()
        {
            _IsRefreshing = true;
            FoodServiceRepository foodServiceRepository = new FoodServiceRepository();
            foreach (var item in await new FoodServiceRepository().GetEmpleados())
            {
                Empleados.Add(item);
            }
            Buscar();
            //var emps = from p in Empleados
            //           where p.Nombre.Contains(ValorBuscar)
            //           select p;

            //var emps =  Empleados.Select(sublist => sublist)
            //             .Where(item => item.Nombre.Contains("wilson"))
            //             .ToList();
            //EmpleadosFiltro.Clear();
            //var emps = Empleados.Where(x => x.Nombre.ToUpper().Contains(ValorBuscar.ToUpper())).OrderBy(o => o.Nombre).ToList();
            //foreach (EmpleadoModel emp in emps)
            //{
            //    EmpleadosFiltro.Add(emp);
            //}

            IsRefreshing = false;

        }
    }
}
