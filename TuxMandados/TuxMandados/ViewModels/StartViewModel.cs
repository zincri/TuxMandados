namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Services;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    public class StartViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Vars
        private bool _isRunning;
        private bool _isEnable;
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

        #region Commands
        public ICommand ChangePageCommand
        {
            get
            {
                return new RelayCommand(ChangePageMethod);
            }
        }
        #endregion

        #region Constructors
        public StartViewModel()
        {
            this.apiService = new ApiService();
            IsEnable = true;
            IsRunning = false;
        }
        #endregion

        #region Methods
        private async void ChangePageMethod()
        {
            IsRunning = true;
            IsEnable = false;


            var conection = await this.apiService.CheckConnection();
            if (!conection.IsSuccess)
            {

                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                "Error",
                    conection.Message,
                "Ok");
                IsRunning = false;
                IsEnable = true;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            //mainViewModel.Next = new NextViewModel();
            //await App.Current.MainPage.Navigation.PushAsync(new Views.NextPage());

            IsRunning = false;
            IsEnable = true;

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
