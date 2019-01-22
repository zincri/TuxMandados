

namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Views;
    using TuxMandados.Interfaces;
    using Xamarin.Forms;
    public class AboutViewModel : INotifyPropertyChanged
    {

        #region Vars  
        private bool _isEnable;
        private string _correo;
        private HtmlWebViewSource _htmlSource;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public HtmlWebViewSource HtmlSource
        {
            get
            {
                return _htmlSource;
            }
            set
            {
                _htmlSource = value;
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
        public AboutViewModel()
        {
            this.Correo = "correo@hotmail.com";
           // HtmlSource.BaseUrl=DependencyService.Get<IBase>
            
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
            await App.Current.MainPage.DisplayAlert("Éxito", "Correo enviado", "ok");
            return;
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
