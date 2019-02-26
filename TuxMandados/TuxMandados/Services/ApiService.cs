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
    using TuxMandados.Domain;
    public class ApiService
    {
         
        /// <summary>
        /// Checks the connection.
        /// Este Metodo sirve para checar la conexion de internet haciendo un ping a Google
        /// Antes de cada servicio se debe validar la conexion, falta pornerle el try y catch
        /// sin try y catch el metodo devolvera una excepcion cuando haga el ping.
        /// </summary>
        /// <returns>The connection.</returns>
        public async Task<Response> CheckConnection()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor checa tu conexion en ajustes.",
                    };
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                    "google.com");
                if (!isReachable)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Checa tu conexion a internet.",
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                };
            }
            catch (Exception)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = "Algo salio mal, vuelve a intentarlo.",
                };
            }
        }

        /// <summary>
        /// Gets the list.
        /// Este Metodo sirve para obtener la lista de mandados realizados(Statica por lo pronto)
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="urlBase">URL base.</param>
        /// <param name="servicePrefix">Service prefix.</param>
        /// <param name="controller">Controller.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
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
                a.Name = "Zincri"; a.Hora = "12:00"; a.Fecha = "12/12/12"; a.Atendido = false;
                b.Name = "Cypres T"; b.Hora = "12:00"; b.Fecha = "12/12/12"; b.Atendido = true;
                c.Name = "Edrey"; c.Hora = "12:00"; c.Fecha = "12/12/12"; c.Atendido = false;
                d.Name = "Ramon"; d.Hora = "12:00"; d.Fecha = "12/12/12"; d.Atendido = false;
                e.Name = "Ayala"; e.Hora = "12:00"; e.Fecha = "12/12/12"; e.Atendido = false;
                f.Name = "Vale"; f.Hora = "12:00"; f.Fecha = "12/12/12"; f.Atendido = false;
                g.Name = "Jajaja"; g.Hora = "12:00"; g.Fecha = "12/12/12"; g.Atendido = false;
                h.Name = "Equis"; h.Hora = "12:00"; h.Fecha = "12/12/12"; h.Atendido = false;
                i.Name = "de"; i.Hora = "12:00"; i.Fecha = "12/12/12"; i.Atendido = false;
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

        /// <summary>
        /// Metodo que sirve para obtener el token de persistencia cuando el usuario se loggea
        /// </summary>
        /// <param name="urlBase"> nos sirve para pasarle la url del servicio</param>
        /// <param name="solicitud">no sirve para mandar los datos de acceso del usuario</param>
        /// <returns></returns>
        public async Task<TokenResponse> GetToken(
            string urlBase,
            SolicitudLogin solicitud)
        {
            try
            {
                var Client = new HttpClient();
                string url = urlBase;
                TokenResponse obj = new TokenResponse();
                var data = JsonConvert.SerializeObject(solicitud);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (TokenResponse)JsonConvert.DeserializeObject(json, typeof(TokenResponse));
                        return resultado;
                        
                    }
                    else
                    {
                        return new TokenResponse
                        {
                            ErrorDescription = "Las credenciales no son validas"
                        };
                    }
                }
                else
                {
                    return new TokenResponse
                    {
                        ErrorDescription = "Ocurrió un error, intentelo mas tarde."
                    };
                }

            }
            catch
            {
                return null;
            }
        }
       
        /// <summary>
        /// Metodo que sirve para enviar cualquier solicitud post
        /// </summary>
        /// <param name="urlBase"> Objeto para pasarle la url del servicio</param>
        /// <param name="solicitud">Objeto para enviar los datos de registro</param>
        /// <returns></returns>
        public async Task<UserResponse> SetUsuario(
            string urlBase,
            SolicitudACUsuario solicitud)
        {
            try
            {
                var Client = new HttpClient();
                string url = urlBase;

                var data = JsonConvert.SerializeObject(solicitud);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (UserResponse)JsonConvert.DeserializeObject(json, typeof(UserResponse));
                        return resultado;
                        
                    }
                
                }
                return null;

            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Metodo que sirve para enviar solicitud post para validar email
        /// </summary>
        /// <param name="urlBase"> Objeto para pasarle la url del servicio</param>
        /// <param name="solicitud">Objeto para enviar el email a validar</param>
        /// <returns></returns>
        public async Task<ValidCorreoResponse> ValidarCorreo(
            string urlBase,
            SolicitudValidUsuario solicitud)
        {
            try
            {
                var Client = new HttpClient();
                string url = urlBase;
                var data = JsonConvert.SerializeObject(solicitud);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (ValidCorreoResponse)JsonConvert.DeserializeObject(json, typeof(ValidCorreoResponse));
                        return resultado;
                    }

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }

}
