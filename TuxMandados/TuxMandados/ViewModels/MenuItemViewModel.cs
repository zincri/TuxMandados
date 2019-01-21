﻿namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Helpers;
    using TuxMandados.Views;

    public class MenuItemViewModel : INotifyPropertyChanged
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string NamePage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        #region Commands

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(NavigateMethod);
            }
        }
        #endregion

        #region Methods
        private void NavigateMethod()
        {
            if(this.NamePage=="LoginPage") 
            {
                Settings.Token = String.Empty;
                Settings.TokenType = String.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = String.Empty;
                mainViewModel.TokenType = String.Empty;
                App.Current.MainPage = new LoginPage();
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