using FoodService.Interfeces;
using FoodService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace FoodService.Services
{
    class DeviceService : IDeviceService
    {
        public bool CheckConnectivity()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
    }
}
