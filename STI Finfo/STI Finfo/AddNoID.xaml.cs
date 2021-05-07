
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
            save.Text = "UPDATE AND SUBMIT REPORT";
            this.Title = "UPDATE AND SUBMIT REPORT";
        }

        private async void SaveNoID(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Alert!", "Update and submit report. Do you want to continue?", "Yes", "No");

            if (result)
            {
                // ----------------- ADD TO LIST  ----------------------
                
                var save = this.FindByName<Button>("saveB");
                if (save.Text == "SUBMIT REPORT")
                {
                    AdminNoID requestss = new AdminNoID
                    {
                        AdminStudentNumber = studentnumber.Text,
                        AdminAccount = account.Text,
                        AdminReasons = reasons.Text,
                        AdminDateNoID = DateID.Text
                    };
                    this.Title = "ADD STUDENT";
                    bool res = DependencyService.Get<ISQLite>().AdminSaveNoID(requestss);
                    if (res == true )
                    {
                        await DisplayAlert("Message", "Report Submitted Successfully ", "Okay");
                        await Navigation.PushAsync(new NoIDTable());
                    }
                    else
                    {
                        await DisplayAlert("Message", "Failed to submit", "Okay");
                    }
                }
                else if (save.Text == "UPDATE AND SUBMIT REPORT")
                {
                    // ----------------- SUBMIT TO ADMIN ----------------------
                    AdminNoID NoIDDetails = new AdminNoID
                    {
                        AdminDateNoID = DateID.Text,
                        AdminStudentNumber = studentnumber.Text,
                        AdminAccount = account.Text,
                        AdminReasons = reasons.Text

                    };
                 
                    this.Title = "UPDATE AND SUBMIT REPORT";
                    bool ADD = DependencyService.Get<ISQLite>().AdminSaveNoID(NoIDDetails);
                    if (ADD == true )
                    {
                      
                        await  DisplayAlert("Message", "Report Submitted Successfully", "Okay");
                        await Navigation.PushAsync(new NoIDTable());
                        
                    }
                    else
                    {
                        await DisplayAlert("Message", "Failed to submit", "Okay");
                    }
                    
                }
            }
            else
            {
                
            }
        }

        private void Date_Clicked(object sender, EventArgs e)
        {
            var dateNoID = this.FindByName<Entry>("DateID");
            dateNoID.Text =  DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            return;
        }
    }
}



