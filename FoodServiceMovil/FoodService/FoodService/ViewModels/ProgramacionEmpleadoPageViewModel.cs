using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodService.ViewModels
{
    public class ProgramacionEmpleadoPageViewModel:BaseViewModel
    {
        //ICommand VerProgramacionCommand { get; set; }
        public EmpleadoModel Empleado { get; set; }
        public ObservableCollection<ProgramacionModel> Programacion { get; set; }
        public ObservableCollection<ProgramacionModel> ProgramacionEmpleado { get; set; }
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
        public ProgramacionEmpleadoPageViewModel(EmpleadoModel empleado)
        {
            Empleado = empleado;
            //VerProgramacionCommand = new Command(VerProgramacion);
            Programacion = new ObservableCollection<ProgramacionModel>();
            ProgramacionEmpleado = new ObservableCollection<ProgramacionModel>();
            CargarProgramacion();
        }

        //public void VerProgramacion()
        //{
        //    ProgramacionEmpleado = new ObservableCollection<ProgramacionModel>();
        //    foreach(var itemProgramacion in Programacion)
        //    {
        //        if (itemProgramacion.IdEmpleado == Empleado.Id)
        //        {
        //            ProgramacionEmpleado.Add(itemProgramacion);
        //        }
        //    }
        //}

        async private void CargarProgramacion()
        {
            IsRefreshing = true;
            FoodServiceRepository foodServiceRepository = new FoodServiceRepository();
            foreach (var item in  await foodServiceRepository.GetProgramacion())
            {
                if (item.IdEmpleado == Empleado.Id)
                {
                    Programacion.Add(item);
                }
            }
            IsRefreshing = false;
        }
    }
}
