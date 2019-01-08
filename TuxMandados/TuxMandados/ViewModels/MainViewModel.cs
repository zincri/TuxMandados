using System;
namespace TuxMandados.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        #endregion
        private static MainViewModel instance;//Objeto principal
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public StartViewModel Start
        {
            get;
            set;
        }
        public NextViewModel Next
        {
            get;
            set;
        }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Start = new StartViewModel();
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
