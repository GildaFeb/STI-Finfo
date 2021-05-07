using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo.Views
{
  
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestForm : ContentPage
    {

        public GuestForm()
        {
            InitializeComponent();
           

        }
        private void SaveRequests(object sender, EventArgs e)
        {
            this.Title = "ADD GUEST";
            var lastname = this.FindByName<Entry>("lastName");
            var firstname = this.FindByName<Entry>("firstName");
            var middlename = this.FindByName<Entry>("middleName");
            var suffix = this.FindByName<Entry>("suffix");
            var age = this.FindByName<Entry>("age");
            var number = this.FindByName<Entry>("contactNumber");
            var address = this.FindByName<Entry>("address");
            var email = this.FindByName<Entry>("email");
            var department = this.FindByName<Entry>("department");
            var transaction = this.FindByName<Entry>("transaction");
          
            var save = this.FindByName<Button>("submit");
            if (save.Text == "SUBMIT")
            {

                Request request = new Request
                {
                    LastName = lastname.Text,
                    FirstName = firstname.Text,
                    MiddleName = middlename.Text,
                    Suffix = suffix.Text,
                    Age = age.Text,
                    Number = number.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Department = department.Text,
                    Transaction = transaction.Text,


                };

                bool res = DependencyService.Get<ISQLite>().SaveRequest(request);
                if (res)
                {

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Save", "Okay");
                }
            }
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<object, string>(this, "Hi", (obj, s) => {
                department.Text = s;
            });
        }
    }
}