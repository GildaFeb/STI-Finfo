using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static STI_Finfo.Admin.GuestViewModel;

namespace STI_Finfo.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestAdmin : ContentPage
    {
        public GuestAdmin()
        {
            InitializeComponent();
        }
        private void ListViewItem_Tabbed(object sender, ItemTappedEventArgs e)
        {
            var list = e.Item as List;
            var vm = BindingContext as GuestViewModel;
            vm?.ShoworHiddenProducts(list);

        }
        private void EditRequest(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Request list)
            {
                Navigation.PushAsync(new AddRequest(list));
            }
        }
    }
}