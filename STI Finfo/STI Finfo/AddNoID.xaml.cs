
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
    public partial class AddNoID : ContentPage
    {
        public AddNoID(NoID details)
        {
            InitializeComponent();
            
            if (details != null)
            {

                PopulateDetails(details);
            }
            

        }
       
        private void PopulateDetails(NoID details)
        {
           
            studentnumber.Text = details.StudentNumber;
            account.Text = details.Account;
            reasons.Text = details.Reasons;
            DateID.Text = details.DateNoID; 
            
            
            var save = this.FindByName<Button>("saveB");
            save.Text = "SUBMIT REPORT";
            this.Title = "SUBMIT REPORT";
        }

        private async void SaveNoID(object sender, EventArgs e)
        {
          
                // ----------------- ADD TO LIST  ----------------------
                
                var save = this.FindByName<Button>("saveB");
                if (save.Text == "SUBMIT REPORT")
                {
                    this.Title = "GUEST FORM";

                    var StudentNo = this.FindByName<Entry>("studentnumber");
                    var Accounts = this.FindByName<Entry>("account");
                    var Reasons = this.FindByName<Entry>("reasons");
                  var Date = this.FindByName<Entry>("DateID"); 


                if (string.IsNullOrEmpty(Accounts.Text) || string.IsNullOrEmpty(StudentNo.Text) || string.IsNullOrEmpty(Reasons.Text) || string.IsNullOrEmpty(Date.Text))
                    {
                        await DisplayAlert("Message", "Failed to submit! Please Complete the form.", "Okay");
                        return;
                    }

                    else if (!(StudentNo.Text.Length == 10) && !(Accounts.Text.Contains("@sjdelmonte.sti.edu.ph")))
                    {
                        await DisplayAlert("Message", "Failed to submit! Student number and O365 account must valid.", "Okay");
                        return;
                    }
                    else if (!(Reasons.Text.Length > 7))
                    {
                       await  DisplayAlert("Message", "Failed to submit! Reason must contain atleast 8 characters", "Okay");
                        return;
                    }
                    else if (!(Accounts.Text.Contains("@sjdelmonte.sti.edu.ph")))
                    {
                        await DisplayAlert ("Message", "Failed to submit. Please enter valid o365 account.", "Okay");
                        return;
                    }
                    else if (!(StudentNo.Text.Length == 10))
                    {
                        await  DisplayAlert("Message", "Failed to submit! Student number must contain 10 characters.", "Okay");
                    }
                    else
                    {
                          
                               AdminNoID requestss = new AdminNoID
                             {
                                   AdminStudentNumber = StudentNo.Text,
                                  AdminAccount = Accounts.Text,
                                  AdminReasons = Reasons.Text,
                                   AdminDateNoID = Date.Text,

                               };

                              bool res = DependencyService.Get<ISQLite>().AdminSaveNoID(requestss);
                              if (res)
                              {
                        var result = await DisplayAlert("Alert!", "Submit report. Do you want to continue?", "Yes", "No");
                        if (result)
                        {
                            await DisplayAlert("Message", "Form Submitted Successfully.", "Okay");
                            await Navigation.PopAsync();
                        }
                              }
                              else
                              {
                            await DisplayAlert("Message", "Failed to submit!", "Okay");
                              }
                           

                    }

                }
               
            
           
        }

        private void Date_Clicked(object sender, EventArgs e)
        {
            var dateNoID = this.FindByName<Entry>("DateID");
            dateNoID.Text =  DateTime.Now.ToString("yyyy/M/d");
            return;
        }
    }
}



