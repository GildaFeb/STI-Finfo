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
        public TableRequest()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateEmployeeList();
        }
        public void PopulateEmployeeList()

        {
            var list = this.FindByName<ListView>("EmployeeList");
            list.ItemsSource = null;
            list.ItemsSource = DependencyService.Get<ISQLite>().GetEmployees();
        }

        private void AddEmployee(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRequest(null));
        }

        private void EditEmployee(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Employee list)
            {
                Navigation.PushAsync(new AddRequest(list));
            }
        }

        private async void DeleteEmployee(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete employee?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Employee details = menu.CommandParameter as Employee;
                DependencyService.Get<ISQLite>().DeleteEmployee(details.Id);
                PopulateEmployeeList();
            }
        }
    }
}
