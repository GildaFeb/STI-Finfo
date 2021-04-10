using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoIDTable : ContentPage
    {
        public NoIDTable()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateNoIDList();
        }
        public void PopulateNoIDList()

        {
            var list = this.FindByName<ListView>("NoIDList");
            list.ItemsSource = null;
            list.ItemsSource = DependencyService.Get<ISQLite>().GetNoID();
        }

        private void AddNoID(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNoID(null));
        }

        private void EditNoID(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is NoID list)
            {
                Navigation.PushAsync(new AddNoID(list));
            }
        }

        private async void DeleteNoID(object sender, EventArgs e)
        {

            bool res = await DisplayAlert("Message", "Do you want to delete request?", "Okay", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                NoID details = menu.CommandParameter as NoID;
                DependencyService.Get<ISQLite>().DeleteNoID(details.NoId);
                PopulateNoIDList();
            }
        }




    }
}
