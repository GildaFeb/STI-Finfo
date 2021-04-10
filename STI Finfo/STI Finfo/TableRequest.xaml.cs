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
    public partial class TableRequest : ContentPage
    {
        

        private ViewCell lastCell;
        public TableRequest()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateRequestList();
        }
        public void PopulateRequestList()

        {
            var list = this.FindByName<ListView>("RequestList");
            list.ItemsSource = null;
            list.ItemsSource = DependencyService.Get<ISQLite>().GetRequest();
        }

        private void AddRequest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRequest(null));
        }

        private void EditRequest(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Request list)
            {
                Navigation.PushAsync(new AddRequest(list));
            }
        }

        private async void DeleteRequest(object sender, EventArgs e)
        {
           
            bool res = await DisplayAlert("Message", "Do you want to delete employee?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Request  details = menu.CommandParameter as Request;
                DependencyService.Get<ISQLite>().DeleteRequest(details.Id);
                PopulateRequestList();
            }
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Yellow;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.DimGray;
                lastCell = viewCell;
            }
        }

       

    }
}
