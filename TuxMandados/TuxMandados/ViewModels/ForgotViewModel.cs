

namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Views;
    public class ForgotViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private bool _isEnable;
        private string _correo;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
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
