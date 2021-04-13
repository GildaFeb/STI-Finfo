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
    }
}