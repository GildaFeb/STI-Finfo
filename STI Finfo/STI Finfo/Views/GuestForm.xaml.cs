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
        private async void SaveRequests(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(lastName.Text) || string.IsNullOrEmpty(firstName.Text) || string.IsNullOrEmpty(department.Text) || string.IsNullOrEmpty(sac.Text) || string.IsNullOrEmpty(age.Text) || string.IsNullOrEmpty(contactNumber.Text) || string.IsNullOrEmpty(address.Text))
            {
                await DisplayAlert("Message", "Failed to submit! All field are required except Middle name, suffix, and email.", "Okay");
                return;
            }

            else if (!(lastName.Text.Length > 1) || !(firstName.Text.Length > 1 || !(middleName.Text.Length > 1)))
            {
                await DisplayAlert("Message", "Failed to submit! Name fields must contain atleast atleast 2 characters", "Okay");
                return;
            }
            else if (!(sac.Text.Length > 6) || !(address.Text.Length > 6))
            {
                await DisplayAlert("Message", "Failed to submit! Transaction, mobile number, and address must contain atleast 7 ", "Okay");
                return;
            }
            else if (!(email.Text.Contains("@")))
            {
                await DisplayAlert("Message", "Invalid email. Try again.", "Okay");
                return;
            }

            else
            {
                var result = await DisplayAlert("Message", "Submit form. Do you want to continue?", "No", "Yes");

                if (result)
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
                            sac = sac.Text,


                        };

                        bool res = DependencyService.Get<ISQLite>().SaveRequest(requests);
                        if (res)
                        {
                            await DisplayAlert("Message", "Form Submitted Successfully", "Okay");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Message", "Data Failed To Save", "Okay");
                        }
                    }
                }
            } 
           
        }

        private async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
     

    }
}