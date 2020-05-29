using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodService.ViewModels
{
    public class FoodServiceHomePageViewModel:BaseViewModel
    {
        private DateTime _Fecha;
        public DateTime Fecha 
        {
            get { return _Fecha; }
            set {
                _Fecha = value;
                CargarPrograma();
            }
        }
        public ObservableCollection<ProgramaDiaModel> Programa { get; set; }
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
        public FoodServiceHomePageViewModel()
        {
            _Fecha = DateTime.Now;
            Programa = new ObservableCollection<ProgramaDiaModel>();
            CargarPrograma();
        }
        async private void CargarPrograma()
        {
            Programa.Clear();
            IsRefreshing = true;
            foreach (var item in await new FoodServiceRepository().GetProgramaDia(_Fecha))
            {
                Programa.Add(item);
            }
            IsRefreshing = false;

        }
    }
}
