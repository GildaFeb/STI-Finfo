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


            var save = this.FindByName<Button>("saveBtn");
            save.Text = "Update";
            this.Title = "Edit request";
        }

        private void SaveRequests(object sender, EventArgs e)
        {
            var save = this.FindByName<Button>("saveBtn");
            if (save.Text == "SUBMIT")
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
                    

                };

                bool res = DependencyService.Get<ISQLite>().SaveRequest(request);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Savessss", "Ok");
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
                };

                bool res = DependencyService.Get<ISQLite>().UpdateRequest(RequestDetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Update", "Ok");
                }
            }
        }
        
    }
}