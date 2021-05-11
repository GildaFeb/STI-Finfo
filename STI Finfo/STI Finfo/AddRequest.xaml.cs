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

            var id = this.FindByName<Entry>("ID");
            var DateGuest = this.FindByName<Entry>("DateGuest");
            
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
            DateGuest.Text = details.DateGuest;
            id.Text = details.Id.ToString();

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
                var result = await DisplayAlert("Message", "Add to list. Do you want to continue?", "Yes", "No");
               if (result)
                {

                    if (string.IsNullOrEmpty(Last.Text) || string.IsNullOrEmpty(First.Text) ||  string.IsNullOrEmpty(Age.Text) || string.IsNullOrEmpty(Number.Text) || string.IsNullOrEmpty(Address.Text))
                    {
                        await DisplayAlert("Message", "Failed to submit! All field are required except Middle name, suffix, and email.", "Okay");
                        return;
                    }

                    else if (!(Last.Text.Length > 1) || !(First.Text.Length > 1 || !(First.Text.Length > 1)))
                    {
                        await DisplayAlert("Message", "Failed to submit! Name fields must contain atleast atleast 2 characters", "Okay");
                        return;
                    }
                    else if (!(sac.Text.Length > 6) || !(Address.Text.Length > 6))
                    {
                        await DisplayAlert("Message", "Failed to submit! Transaction, mobile number, and address must contain atleast 7 ", "Okay");
                        return;
                    }
                    else if (!(Email.Text.Contains("@")))
                    {
                        await DisplayAlert("Message", "Invalid email. Try again.", "Okay");
                        return;
                    }
                    else
                    {
                        var choose = await DisplayAlert("Alert!", "Add to List. Do you want to continue?", "Yes", "No");
                        if (choose)
                        {
                            var DateGuest = this.FindByName<Entry>("DateGuest");
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
                                TimeOut = TimeOut.Text,
                                DateGuest = DateGuest.Text
                            };

                            bool res = DependencyService.Get<ISQLite>().SaveRequest(request);
                            if (res)
                            {
                                await DisplayAlert("Message", "Successfully Added to List", "Okay");
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                await DisplayAlert("Message", "Data Failed To Save", "Okay");
                            }
                        }
                          
                    }


                    //==============================
                  
                }
            }
            else
            {
                var choose = await DisplayAlert("Alert!", "Update this Form. Do you want to continue?", "Yes", "No");
                if (choose)
                {
                    var DateGuest = this.FindByName<Entry>("DateGuest");

                    var id = this.FindByName<Entry>("ID");
                    int result = Int32.Parse(id.Text);
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
                        Id = result,
                        DateGuest = DateGuest.Text
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
        }

       

        private void TimeIn_Clicked(object sender, EventArgs e)
        {
            
            var inTime = this.FindByName<Entry>("TimeIn");
            inTime.Text = DateTime.Now.ToString("HH:mm:ss"); 
            return;
        }
        private void TimeOut_Clicked(object sender, EventArgs e)
        {
            var inTime = this.FindByName<Entry>("TimeOut");
            inTime.Text = DateTime.Now.ToString("HH:mm:ss");
            return;
        }
        private async void Report_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Alert!", "Submit report. Do you want to continue?", "Yes", "No");
            if (result)
            {
                if (string.IsNullOrEmpty(Last.Text) || string.IsNullOrEmpty(First.Text) || string.IsNullOrEmpty(department.Text) || string.IsNullOrEmpty(sac.Text) || string.IsNullOrEmpty(Age.Text) || string.IsNullOrEmpty(Number.Text) || string.IsNullOrEmpty(Address.Text) || string.IsNullOrEmpty(DateGuest.Text))
                {
                    await DisplayAlert("Message", "Failed to submit! All fields are required except middle name, suffix, and email.", "Okay");
                    return;
                }

                else if (!(Last.Text.Length > 1) || !(First.Text.Length > 1 || !(First.Text.Length > 1)))
                {
                    await DisplayAlert("Message", "Failed to submit! Name fields must contain atleast atleast 2 characters", "Okay");
                    return;
                }
                else if (!(sac.Text.Length > 6) || !(Address.Text.Length > 6))
                {
                    await DisplayAlert("Message", "Failed to submit! Transaction, mobile number, and address must contain atleast 7 ", "Okay");
                    return;
                }
                else if (!(Email.Text.Contains("@")))
                {
                    await DisplayAlert("Message", "Invalid email. Try again.", "Okay");
                    return;
                }
                else
                {

                    var choose = await DisplayAlert("Alert!", "Submit report. Do you want to continue?", "Yes", "No");
                    if (choose)
                    {
                        var DateGuest = this.FindByName<Entry>("DateGuest");
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
                            TimeIn = TimeIn.Text,
                            TimeOut = TimeOut.Text,
                            DateGuest = DateGuest.Text
                        };

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

        private void Date_Clicked(object sender, EventArgs e)
        {
            var dateNoID = this.FindByName<Entry>("DateGuest");
            dateNoID.Text = DateTime.Now.ToString("yyyy/M/d");
            return;
        }
    }
}