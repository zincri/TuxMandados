﻿namespace TuxMandados.Services
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
        //Method que nos sirve para checar la conexion de internet haciendo un ping a Google 
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

        //Method que nos sirve para obtener la lista de mandados realizados(Statica por lo pronto)
        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                //string URL = string.Format("http://restcountries.eu/rest/v2/all");
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                //var response = await client.GetAsync(url);
                List<Order> list = new List<Order>();
                Order a = new Order();
                Order b = new Order();
                Order c = new Order();
                Order d = new Order();
                Order e = new Order();
                Order f = new Order();
                Order g = new Order();
                Order h = new Order();
                Order i = new Order();
                a.Name = "Zincri"; a.Hora = "12:00"; a.Fecha = "12/12/12";
                b.Name = "Jesus"; b.Hora = "12:00"; b.Fecha = "12/12/12";
                c.Name = "Edrey"; c.Hora = "12:00"; c.Fecha = "12/12/12";
                d.Name = "Zincri"; d.Hora = "12:00"; d.Fecha = "12/12/12";
                e.Name = "Jesus"; e.Hora = "12:00"; e.Fecha = "12/12/12";
                f.Name = "Edrey"; f.Hora = "12:00"; f.Fecha = "12/12/12";
                g.Name = "Zincri"; g.Hora = "12:00"; g.Fecha = "12/12/12";
                h.Name = "Jesus"; h.Hora = "12:00"; h.Fecha = "12/12/12";
                i.Name = "Edrey"; i.Hora = "12:00"; i.Fecha = "12/12/12";
                list.Add(a);
                list.Add(b);
                list.Add(c);
                list.Add(d);
                list.Add(e);
                list.Add(f);
                list.Add(g);
                list.Add(h);
                list.Add(i);

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

        //Method que nos sirve para obtener un token cuando el usuario se loggea
        public async Task<TokenResponse> GetToken(
            string urlBase,
            string username,
            string password)
        {
            try
            {
                //var client = new HttpClient();
                //client.BaseAddress = new Uri(urlBase);
                //var response = await client.PostAsync("Token",
                //    new StringContent(string.Format(
                //    "grant_type=password&username={0}&password={1}",
                //    username, password),
                //    Encoding.UTF8, "application/x-www-form-urlencoded"));
                //var resultJSON = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<TokenResponse>(
                //    resultJSON);
                //return result;
                if (!(username.Equals("usuario")) || !(password.Equals("123456")))
                {
                    return new TokenResponse
                    {
                        ErrorDescription = "Las credenciales no son validas"
                    };
                }
                else 
                {
                    return new TokenResponse
                    {
                        AccessToken = "6cuIiwbghKtnMkcbpbKr7gF4nZ4AErIsvyuvdSfz84ve9qQTyBvwCFsaXsGJikeT\n23mFFe4cptahbuR58ejeuLG0frCQ9VNVFZmzp7e9OkB6A0toXrCnsVo9QYIEHFa3\nbg5G7lgo3iaGNC712QpeBik4Hy71i6MvApFH8GgDXkP3V1ZIR3mdhtbEeOdUzBcl\nRwUWGvCGaZ0Xj1CMR19lKfu8F8D2EEBesb3Tk4LuXUz2fg7UXMvHo8TYhKeazgvz\nYe7Ou453IpDozQzhDQEjoyPpmMyuAHW1UhZIA6lP4U76xeejO5kJAGNO3JMs56e0\nmh1JsArQ8mMSoK8l9D0qLXLDJxyC7m5BiWkrQ66T5LYNMaWySTS3Qn4NDI0gKOE5\nvBrsCJxIVMEuw5BvadUyboQM7HCvRBBf28VoHKLmSBzoTqiDKDSZ9xLCJ9QzBBz2\nzmiDi2oZK9FZwUCd9MHgFbcodadpYleOmrteLIF5pqWagJ8MickwK1HiQybspo5L\nQEEK6i7Oi2iK2lGOPWJd00WWrbaGJl1iL7C1mhHQsuJFOuGIkeNvSnVB6WXaicwF\nb6XAM4TsfUz0a404zT79YV17SnszLShh5uvsxUqkpugIuxZ6MwOiOGakKd7EOpnX",
                        TokenType = "owner"
                        //TokenType = "bearer"
                    };
                }



            }
            catch
            {
                return null;
            }
        }


    }

}
