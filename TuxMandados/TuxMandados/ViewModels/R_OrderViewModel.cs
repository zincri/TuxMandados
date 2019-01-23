namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using TuxMandados.Models;
    public class R_OrderViewModel
    {
        #region Vars
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public Order Order
        {
            get;
            set;
        }

        #endregion

        #region Commands
        #endregion

        #region Constructors
        public R_OrderViewModel(Order order)
        {
            this.Order = order;
        }
        #endregion

        #region Methods
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
