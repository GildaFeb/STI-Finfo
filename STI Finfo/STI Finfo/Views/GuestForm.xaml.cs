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
            this.Title = "ADD GUEST";

        }
        private void SaveRequests(object sender, EventArgs e)
        {


            var save = this.FindByName<Button>("submit");
            if (save.Text == "SUBMIT")
            {

                Request requests = new Request
                {
                    LastName = lastName.Text,
                    FirstName = firstName.Text,
                    MiddleName = middleName.Text,
                    Suffix = suffix.Text,
                    Age = age.Text,
                    Number = contactNumber.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Department = department.Text,
                    Transaction = transaction.Text,


                };

                bool res = DependencyService.Get<ISQLite>().SaveRequest(requests);
                if (res)
                {
                    DisplayAlert("Message", "Form Submitted Successfully", "Okay");
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
     

    }
}