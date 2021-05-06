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
       
        public void PopulateNoIDList()

        {
            var list = this.FindByName<ListView>("adminList");
            list.ItemsSource = null;
            list.ItemsSource = DependencyService.Get<ISQLite>().GetNoIDToday();
        }
        private async void DeleteNoID(object sender, EventArgs e)
        {

            bool res = await DisplayAlert("Message", "Do you want to delete request?", "Yes", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                AdminNoID details = menu.CommandParameter as AdminNoID;
                DependencyService.Get<ISQLite>().DeleteNoID(details.AdminNoId);
                PopulateNoIDList();
            }
        }
    }
}