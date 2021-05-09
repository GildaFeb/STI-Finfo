using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static STI_Finfo.Admin.MainViewModel;

namespace STI_Finfo.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListviewDetails : ContentPage
    {
        public ListviewDetails()
        {
            InitializeComponent();
        }
        private void ListViewItem_Tabbed(object sender, ItemTappedEventArgs e)
        {
            var list = e.Item as List;
            var vm = BindingContext as MainViewModel;
            vm?.ShoworHiddenProducts(list);

        }
        public List<AdminNoID> tempdata;
        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var GuestList = this.FindByName<ListView>("AdminList");
            var data = DependencyService.Get<ISQLite>().AdminGetNoID();
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                GuestList.ItemsSource = data;
            }

            else
            {
                GuestList.ItemsSource = data.Where(x => x.AdminAccount.Contains(e.NewTextValue));
            }
        }

    }
}