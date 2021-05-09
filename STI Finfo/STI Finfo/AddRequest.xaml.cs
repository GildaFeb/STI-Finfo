using STI_Finfo.Views;
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
    public partial class AddRequest : ContentPage
    {
        
        public AddRequest(Request details)
        {

            InitializeComponent();
            if (details != null)
            {
                 
                PopulateDetails(details);
            }
          
            
        }

       
        private void PopulateDetails(Request details)
        {


            Last.Text = details.LastName;
            First.Text = details.FirstName;
            Middle.Text = details.MiddleName;
            Suffix.Text = details.Suffix;
            Age.Text = details.Age;
            Number.Text = details.Number;
            Address.Text = details.Address;
            Email.Text = details.Email;
            sac.Text = details.sac;
            department.Text = details.Department;
            TimeIn.Text = details.TimeIn;
            TimeOut.Text = details.TimeOut;

            var save = this.FindByName<Button>("saveBtn");
            save.Text = "UPDATE ONLY";
            var submit = this.FindByName<Button>("ToAdmin");
            submit.Text = "SUBMIT REPORT";
            this.Title = "EDIT";
           
        }

        private async void SaveRequests(object sender, EventArgs e)
        {
            this.Title = "ADD GUEST";
            var save = this.FindByName<Button>("saveBtn");
            if (save.Text == "ADD TO REQUEST LIST")
            {

                Request request = new Request
                {
                    LastName = Last.Text,
                    FirstName = First.Text,
                    MiddleName = Middle.Text,
                    Suffix = Suffix.Text,
                    Age = Age.Text,
                    Number = Number.Text,
                    Address = Address.Text,
                    Email = Email.Text,
                    Department = department.Text,
                    sac = sac.Text,
                    TimeIn = TimeIn.Text,
                    TimeOut = TimeOut.Text

                };

                bool res = DependencyService.Get<ISQLite>().SaveRequest(request);
                if (res)
                {
                    await DisplayAlert ("Message", "Successfully Added to List", "Okay");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert ("Message", "Data Failed To Save", "Okay");
                }
            }
            else
            {
                // update request
                Request RequestDetails = new Request
                {
                    LastName = Last.Text,
                    FirstName = First.Text,
                    MiddleName = Middle.Text,
                    Suffix = Suffix.Text,
                    Age = Age.Text,
                    Number = Number.Text,
                    Address = Address.Text,
                    Email = Email.Text,
                    TimeIn = TimeIn.Text,
                    TimeOut = TimeOut.Text,
                    sac = sac.Text,
                    Department = department.Text,
                };

                bool res = DependencyService.Get<ISQLite>().UpdateRequest(RequestDetails); 
                
                if (res == true)
                {
                    await DisplayAlert("Message", "Form Updated Successfully", "Okay");
                    await Navigation.PushAsync(new TableRequest());
                }
                else
                {
                    await DisplayAlert("Message", "Data Failed To Update", "Okay");
                }
            }
        }

       

        private void TimeIn_Clicked(object sender, EventArgs e)
        {
            
            var inTime = this.FindByName<Entry>("TimeIn");
            inTime.Text = DateTime.Now.ToString("yyyy/M/d HH:mm:ss"); 
            return;
        }
        private void TimeOut_Clicked(object sender, EventArgs e)
        {
            var inTime = this.FindByName<Entry>("TimeOut");
            inTime.Text = DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            return;
        }
        private async void Report_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Alert!", "Update and submit report. Do you want to continue?", "Yes", "No");
            if (result)
            {
                AdminRequest RequestDetails = new AdminRequest
                {
                    LastName = Last.Text,
                    FirstName = First.Text,
                    MiddleName = Middle.Text,
                    Suffix = First.Text,
                    Age = Age.Text,
                    Number = Number.Text,
                    Address = Address.Text,
                    Email = Email.Text,
                    Department = department.Text,
                    sac = sac.Text,
                    TimeIn =TimeIn.Text,
                    TimeOut= TimeOut.Text
                };
                this.Title = "UPDATE AND SUBMIT REPORT";
                bool ADD = DependencyService.Get<ISQLite>().AdminSaveGuest(RequestDetails);
                if (ADD == true)
                {

                    await DisplayAlert("Message", "Report Submitted Successfully", "Okay");
                    await Navigation.PushAsync(new TableRequest());

                }
                else
                {
                    await DisplayAlert("Message", "Failed to submit", "Okay");
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