

namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Views;
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private bool _isEnable;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
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
        public HomeViewModel()
        {
        }
        #endregion

        #region Commands

        public ICommand TuxMandarCommand
        {
            get
            {
                return new RelayCommand(TuxMandarMethod);
            }
        }

        #endregion



        #region Methods

        private async void TuxMandarMethod()
        {
            //await App.Current.MainPage.DisplayAlert("Correcto","Tuxmandado","ok");
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Order = new OrderViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new OrderPage());
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
