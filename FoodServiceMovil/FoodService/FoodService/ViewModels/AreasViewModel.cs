using FoodService.Models;
using FoodService.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FoodService.ViewModels
{
    public class AreasViewModel : BaseViewModel
    {
        public ObservableCollection<AreaModel> Areas { get; set; }
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
        public AreasViewModel()
        {
            Areas = new ObservableCollection<AreaModel>();
            LoadAreas();
        }


        async private void LoadAreas()
        {
            IsRefreshing = true;
            foreach (var item in await new FoodServiceRepository().GetAreas())
            {
                Areas.Add(item);
            }
            IsRefreshing = false;
        }
    }
}
