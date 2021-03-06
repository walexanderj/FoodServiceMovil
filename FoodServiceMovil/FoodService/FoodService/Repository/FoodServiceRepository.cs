﻿using FoodService.Interfeces;
using FoodService.Models;
using FoodService.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodService.Repository
{
    class FoodServiceRepository
    {
        private string Url = "http://10.16.9.22:8091/Api/";
        async public Task<UsuarioModel> GetUsuario(LoginModel item)
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(item);
                    var contentSend = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(Url + "Login"), contentSend);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<UsuarioModel>(content);
                    }
                }
            }
            return null;
        }

        async public Task<IEnumerable<ProgramacionModel>> GetProgramacion()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(Url + "Programacion"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<ProgramacionModel>>(content);
                    }
                }
            }
            return null;
        }

        async public Task<List<AreaModel>> GetAreas()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(Url + "Area"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<AreaModel>>(content);
                    }
                }
            }
            return null;
        }


        async public Task<AreaModel> GetArea(int id)
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(Url + "Area/" + id.ToString()));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<AreaModel>(content);
                    }
                }
            }
            return null;
        }

        async public Task<List<TurnoModel>> GetTurnos()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(Url + "Turno"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<TurnoModel>>(content);
                    }
                }
            }
            return null;
        }
        async public Task<List<EmpleadoModel>> GetEmpleados()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new Uri(Url + "Empleado"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<EmpleadoModel>>(content);
                    }
                }
            }
            return null;
        }
        async public Task<bool> AddNovedad(NovedadModel item)
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(item);
                    var contentSend = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(new Uri(Url + "Novedad"), contentSend);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        async public Task<List<ProgramaDiaModel>> GetProgramaDia(DateTime fecha)
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    //var json = JsonConvert.SerializeObject(fecha.ToString("yyyyMMdd"));
                    //var contentSend = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.GetAsync(new Uri(Url + "ProgramaDia/" + fecha.ToString("yyyyMMdd")));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<ProgramaDiaModel>>(content);
                    }
                }
            }
            return null;
        }
    }
}
