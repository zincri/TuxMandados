

namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Helpers;
    using TuxMandados.Services;
    using TuxMandados.Views;
    using Xamarin.Forms;
    //using Xamarin.Essentials;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Mail;
    using TuxMandados.Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Acr.UserDialogs;
    using System.Net;

    public class ForgotViewModel : INotifyPropertyChanged
    {
        #region Private Vars
        private ApiService apiService;
        SolicitudValidUsuario soli;
        Recovery reco;
        #endregion
        #region Vars  
        private bool _isEnable;
        private string _correo;
        private bool _isRunning;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public string Correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public ForgotViewModel()
        {
            this.Correo = "correo@hotmail.com";
            this.apiService = new ApiService();
        }
        #endregion

        #region Commands

        public ICommand SendCommand
        {
            get
            {
                return new RelayCommand(SendMethod);
            }
        }

        

        #endregion



        #region Methods       
        private async void SendMethod()
        {
            if (string.IsNullOrEmpty(this.Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo email está vacío!",
                    "Ok");
                return;
            }
            if (!RegexUtilities.IsValidEmail(this.Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "¡¡Ingresa un correo valido !!",
                    "Ok");
                return;
            }
           this.IsRunning = true;
           this.IsEnable = false;
            var checkConnetion = await this.apiService.CheckConnection();
            if (!checkConnetion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Checa tu conexion a internet!",
                    "Ok");
                return;
            }
            reco = new Recovery();

            CallService();
           
            
           
        }
        private void CallService()
        {
            
            bool success = false;
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Enviando Correo...", MaskType.Black));
                Task.Run(async () =>
                {

                    soli = new SolicitudValidUsuario();
                    soli.correo = this.Correo;
                    var res = await this.apiService.ValidarCorreo(
                         "http://www.creativasoftlineapps.com/ScriptAppTuxmandados/frmValidarCorreo.aspx",
                         soli);
                    if (res != null)
                    {
                        reco.Valido = res.Valido;
                        reco.Token = res.Token;
                        success = true;
                    }
                }).ContinueWith(res => Device.BeginInvokeOnMainThread(async () =>
                {
                    if (success == false)
                    {
                        await App.Current.MainPage.DisplayAlert("Ocurrió un error", "El correo ingresado no es valido", "Aceptar");
                        UserDialogs.Instance.HideLoading();
                       
                    }
                    else
                    {
                        await EnviarCorreo("Buen día, lamentamos que haya perdido su contraseña para obtener de nuevo su acceso a Tuxmandados haga" +
                   " lo siguiente: Copie el token: " + reco.Token + " y a continuación ingrese a la siguiente pagina http://www.creativasoftlineapps.com/ScriptAppTuxmandados/frmRecuperarContraseña.aspx para seguir con el proceso " +
                   " de recuperacion de su cuenta.");
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert("Éxito", "Correo enviado", "ok");
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }));
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Ocurrió un error", ex.ToString(), "Aceptar");
            }
             
        }
        public async Task EnviarCorreo(string mensaje)
        {
            

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("tuxmandados.18@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add(Correo);//este es el correo al que llegara el correo
                mail.Subject = "Recuperacion de contraseña";// El titulo del mensaje
                mail.IsBodyHtml = false;
                mail.Body = mensaje;//El mensaje que se almaceno en el estring
               
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tuxmandados.18@gmail.com", "Tu%m4nd4d0s");// aqui debe ir nuestro correo Gmail y nuestra contraseña
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
                    return true;
                };
                SmtpServer.Send(mail);
                
            }

            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
               "Error",
               "Ocurrio un problema enviando el correo de recuperacion",
               "Ok");
            }
        }
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


    }
}
