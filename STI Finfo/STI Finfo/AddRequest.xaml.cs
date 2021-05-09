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
            first.Text = details.FirstName;
           middle.Text = details.MiddleName;
          
            age.Text= details.Age;
            number.Text = details.Number;
            address.Text = details.Address;
            email.Text = details.Email;
            transaction.Text = details.Transaction;
            department.Text = details.Department;
            TimeIn.Text = details.TimeIn; 
            TimeOut.Text = details.TimeOut;

            var save = this.FindByName<Button>("saveBtn");
            save.Text = "UPDATE ONLY";
            var submit = this.FindByName<Button>("ToAdmin");
            submit.Text = "SUBMIT REPORT";
            this.Title = "EDIT";
           
        }

        private void SaveRequests(object sender, EventArgs e)
        {
            this.Title = "ADD GUEST";
            var save = this.FindByName<Button>("saveBtn");
            if (save.Text == "ADD TO REQUEST LIST")
            {

                Request request = new Request
                {
                    LastName = Last.Text,
                    FirstName = first.Text,
                    MiddleName = middle.Text,
                    Suffix = first.Text,
                    Age = age.Text,
                    Number = number.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Department = department.Text,
                    Transaction = transaction.Text,
                    TimeIn = TimeIn.Text,
                    TimeOut = TimeOut.Text

                };

                bool res = DependencyService.Get<ISQLite>().SaveRequest(request);
                if (res)
                {
                    DisplayAlert("Message", "Successfully Added to List", "Okay");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Save", "Okay");
                }
            }
            else
            {
                // update request
                Request RequestDetails = new Request
                {
                    LastName = Last.Text,
                    FirstName = first.Text,
                    MiddleName = middle.Text,
                    Suffix = first.Text,
                    Age = age.Text,
                    Number = number.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Department = department.Text,
                    Transaction = transaction.Text,
                    TimeIn = TimeIn.Text,
                    TimeOut = TimeOut.Text
                };

                bool res = DependencyService.Get<ISQLite>().UpdateRequest(RequestDetails); 
                
                if (res)
                {
                    
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Update", "Okay");
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
                    FirstName = first.Text,
                    MiddleName = middle.Text,
                    Suffix = first.Text,
                    Age = age.Text,
                    Number = number.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Department = department.Text,
                    Transaction = transaction.Text,
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