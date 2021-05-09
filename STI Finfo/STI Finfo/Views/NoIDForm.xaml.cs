using STI_Finfo.NoIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoIDForm : ContentPage
    {
        public NoIDForm()
        {
            InitializeComponent();
            BindingContext = new NoIDPageViewModel();
        }


        private async void SaveNoID(object sender, EventArgs e)
        {


            this.Title = "GUEST FORM";
            
            var StudentNo = this.FindByName<Entry>("studentnumber");
            var Accounts = this.FindByName<Entry>("account");
            var Reasons = this.FindByName<Entry>("reasons");

            
            if (string.IsNullOrEmpty(Accounts.Text) || string.IsNullOrEmpty(StudentNo.Text) || string.IsNullOrEmpty(Reasons.Text))
            {
                await DisplayAlert("Message", "Failed to submit! Please Complete the form.", "Okay");
                return;
            }
           
            else if (!(StudentNo.Text.Length == 10) && !(Accounts.Text.Contains("@sjdelmonte.sti.edu.ph")))
            {
                await DisplayAlert("Message", "Failed to submit! Student number and O365 account must valid.", "Okay");
                return;
            }
            else if (!(Reasons.Text.Length > 7 ))
            {
                await DisplayAlert("Message", "Failed to submit! Reason must contain atleast 8 characters", "Okay");
                return;
            }
            else if (!(Accounts.Text.Contains("@sjdelmonte.sti.edu.ph")))
            {
                await DisplayAlert("Message", "Failed to submit. Please enter valid o365 account.", "Okay");
                return;
            }
            else if (!(StudentNo.Text.Length == 10))
            {
                await DisplayAlert("Message", "Failed to submit! Student number must contain 10 characters.", "Okay");
            }
            else
            {
                var result = await DisplayAlert("Alert!", "Submit form. Do you want to continue?", "Yes", "No");

                if (result)
                {
                    NoID requestss = new NoID
                    {
                        StudentNumber = StudentNo.Text,
                        Account = Accounts.Text,
                        Reasons = Reasons.Text,

                    };

                    bool res = DependencyService.Get<ISQLite>().SaveNoID(requestss);
                    if (res)
                    {
                        await DisplayAlert ("Message", "Form Submitted Successfully.", "Okay");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert ("Message", "Failed to submit!", "Okay");
                    }
                   
                }
                else { }
            }
          
            
        }
    }
}