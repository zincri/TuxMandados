namespace TuxMandados.ViewModels
{
    using System.Collections.Generic;
    using TuxMandados.Models;

    public class MainViewModel
    {
        #region Properties
        public List<Land> OrdersList
        {
            get;
            set;
        }
        #endregion
        private static MainViewModel instance;//Objeto principal
        #region ViewModels
        public OrderViewModel Order
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
        public MenuViewModel Menu
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
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Methods

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            return instance;
        }
        #endregion
    }
}
