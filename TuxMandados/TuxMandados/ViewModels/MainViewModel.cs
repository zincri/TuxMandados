namespace TuxMandados.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using TuxMandados.Models;

    public class MainViewModel
    {
        #region Properties
        public List<Order> OrdersList
        {
            get;
            set;
        }
        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        public string Token
        {
            get;
            set;
        }
        public string TokenType
        {
            get;
            set;
        }
        #endregion
        private static MainViewModel instance;//Objeto principal
        #region ViewModels
        public AboutViewModel About
        {
            get;
            set;
        }
        /* Borrada temporalmente
        public ProfileViewModel Profile
        {
            get;
            set;
        }
        */
        public NewOrderViewModel NewOrder
        {
            get;
            set;
        }
        public ForgotViewModel Forgot
        {
            get;
            set;
        }
        public LoginViewModel Login
        {
            get;
            set;
        }
        public HomeViewModel Home
        {
            get;
            set;
        }
        /* Borrada temporalmente
        public MenuViewModel Menu
        {
            get;
            set;
        }
        */
        public NewClientViewModel NewClient
        {
            get;
            set;
        }
        public OrdersViewModel Orders
        {
            get;
            set;
        }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Methods

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            return instance;
        }
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                NamePage = "LoginPage",
                Title = "Mi Perfil"
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                NamePage = "LoginPage",
                Title = "Salir"
            }
            );
        }
        #endregion
    }
}
