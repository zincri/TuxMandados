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
        /*Posiblemente no nos sirve
        public List<Order> R_OrdersList
        {
            get;
            set;
        }*/
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

        public TokenResponse TokenResponse
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
       
        public ProfileViewModel Profile
        {
            get;
            set;
        }
        
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
        public OrderViewModel Order
        {
            get;
            set;
        }
        public R_OrderViewModel R_Order
        {
            get;
            set;
        }
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
        public R_OrdersViewModel R_Orders
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
            //Ya no importa tener el LoadMenu aqui -> puedes quitarlo
            //this.LoadMenu(); //Comentare el menu porque no se como instanciarlo al mismo tiempo sin obtener el tokenType
        }
        #endregion

        #region Methods

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            return instance;
        }
        public void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            if (TokenType.Equals("repartidor")) 
            {
                this.Menus.Add(new MenuItemViewModel
                {
                    Icon = "ic_settings",
                    NamePage = "Perfil",
                    Title = "Mi Perfil"
                });
                this.Menus.Add(new MenuItemViewModel
                {
                    Icon = "ic_settings",
                    NamePage = "LoginPage",
                    Title = "Mi Perfil"
                });
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
            else 
            {
                this.Menus.Add(new MenuItemViewModel
                {
                    Icon = "ic_settings",
                    NamePage = "Perfil",
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


        }
        #endregion
    }
}
