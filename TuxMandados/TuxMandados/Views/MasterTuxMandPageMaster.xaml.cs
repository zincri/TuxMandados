using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuxMandados.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterTuxMandPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterTuxMandPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterTuxMandPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterTuxMandPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterTuxMandPageMenuItem> MenuItems { get; set; }
            
            public MasterTuxMandPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterTuxMandPageMenuItem>(new[]
                {
                    new MasterTuxMandPageMenuItem { Id = 0, Title = "Page 1" },
                    new MasterTuxMandPageMenuItem { Id = 1, Title = "Page 2" },
                    new MasterTuxMandPageMenuItem { Id = 2, Title = "Page 3" },
                    new MasterTuxMandPageMenuItem { Id = 3, Title = "Page 4" },
                    new MasterTuxMandPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}