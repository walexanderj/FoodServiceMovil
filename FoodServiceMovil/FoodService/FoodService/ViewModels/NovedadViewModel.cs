using FoodService.Interfeces;
using FoodService.Models;
using FoodService.Repository;
using FoodService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodService.ViewModels
{
    public class NovedadViewModel : BaseViewModel
    {
        public ICommand GuardarNovedadCommand { get; set; }
        public ObservableCollection<EmpleadoModel> Empleados { get; set; }

        public ObservableCollection<ConceptoModel> Conceptos { get; set; }

        public ObservableCollection<TurnoModel> Turnos { get; set; }
        public string TipoNovedad { get; set; }
        public ConceptoModel SeletedConcepto { get; set; }
        public TurnoModel SelectedTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public NovedadModel Novedad { get; set; }
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
        public NovedadViewModel(string tipoNovedad, List<EmpleadoModel> empleados)
        {
            GuardarNovedadCommand = new Command(GuardarNovedad);
            Empleados = new ObservableCollection<EmpleadoModel>();
            Conceptos = new ObservableCollection<ConceptoModel>();
            Turnos = new ObservableCollection<TurnoModel>();
            TipoNovedad = tipoNovedad;
            SeletedConcepto = new ConceptoModel(0,"","");
            SelectedTurno = new TurnoModel();
            FechaInicio = DateTime.Now;
            FechaFinal = DateTime.Now;
            Novedad = new NovedadModel();
            ListarEmpleados(empleados);
            ListarConceptos();
            ListarTurnos();
        }
        async private void GuardarNovedad()
        {
            FoodServiceRepository foodServiceRepository = new FoodServiceRepository();
            DateTime f1 = FechaInicio;
            DateTime f2 = FechaFinal;
            while (f1 <= f2)
            {
                foreach(var empleado in Empleados)
                {
                    NovedadModel novedad = new NovedadModel();
                    novedad.idPlato = 0;
                    novedad.idTurnoDetalle = 0;
                    novedad.Fecha = f1;
                    novedad.IdEmpleado = empleado.Id;
                    novedad.Detalle = SeletedConcepto.Descripcion;
                    novedad.Notas = Novedad.Notas;
                    novedad.FechaIng = DateTime.Now;
                    novedad.UsuarioIng = VariablesGlobales.USER.UserName;
                    if (TipoNovedad == "Cancel")
                    {
                        novedad.NoAlimentacion = true;
                    }
                    if (TipoNovedad == "New")
                    {
                        novedad.NoAlimentacion = false;
                    }
                    if (TipoNovedad == "Change")
                    {
                        novedad.NoAlimentacion = false;
                        novedad.idPlato = SelectedTurno.IdPlato;
                        novedad.idTurnoDetalle = SelectedTurno.Id;
                    }
                    await foodServiceRepository.AddNovedad(novedad);
                }
                
                f1 = f1.Date.AddDays(1);
            }
            var navigationService = new NavigationService();
            navigationService.NavigateToDashboard();
        }

        private void ListarConceptos()
        {
            Conceptos.Add(new ConceptoModel(3, "INCAPACIDADES X AT", "Novedad"));
            Conceptos.Add(new ConceptoModel(7, "VACACIONES", "Novedad"));
            Conceptos.Add(new ConceptoModel(11, "PERMISOS APROBADOS", "Novedad"));
            Conceptos.Add(new ConceptoModel(12, "INCAPACIDADES X EG", "Novedad"));
            Conceptos.Add(new ConceptoModel(16, "VIAJE", "Novedad"));
            Conceptos.Add(new ConceptoModel(17, "REUNION / CAPACITACIÓN", "Novedad"));
        }
        private void ListarEmpleados(List<EmpleadoModel> lista)
        {
            IsRefreshing = true;
            var empleados = new ObservableCollection<EmpleadoModel>(lista);
            foreach (var itemEmpleado in empleados)
            {
                Empleados.Add(itemEmpleado);
            }
            IsRefreshing = false;
        }

        async private void ListarTurnos()
        {

            foreach (var item in await new FoodServiceRepository().GetTurnos())
            {
                Turnos.Add(item);
            }
        }
    }
}
