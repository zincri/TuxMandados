namespace TuxMandados.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;
    using Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check you internet connection.",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                //var client = new HttpClient();
                //string URL = string.Format("http://restcountries.eu/rest/v2/all");
                //client.BaseAddress = new Uri(urlBase);
                //var url = string.Format("{0}{1}", servicePrefix, controller);
                //string a = "b";
                //var response = await client.GetAsync(URL);
                List<Order> list = new List<Order>();
                Order a = new Order();
                Order b = new Order();
                Order c = new Order();

                a.Name = "Zincri"; a.Hora = "12:00"; a.Fecha = "12/12/12";
                b.Name = "Jesus"; b.Hora = "12:00"; b.Fecha = "12/12/12";
                c.Name = "Edrey"; c.Hora = "12:00"; c.Fecha = "12/12/12";
                list.Add(a);
                list.Add(b);
                list.Add(c);

                var result = list;//await response.Content.ReadAsStringAsync();//Aqui llenar la lista

                /*if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }*/


                var listout = list;//JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = listout,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


    }

}
