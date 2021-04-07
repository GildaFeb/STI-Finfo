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
        
        public AddRequest(Employee details)
        {
           
            InitializeComponent();
            if (details != null)
            {
                 
                PopulateDetails(details);
            }
          
            
        }

        private void PopulateDetails(Employee details)
        {
            name.Text = details.Name;
            address.Text = details.Address;
            phoneNumber.Text = details.PhoneNumber;
            email.Text = details.Email;
            
            saveBtn.Text = "Update";
            this.Title = "Edit Employee";
        }

        private void SaveEmployee(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                Employee employee = new Employee
                {
                    Name = name.Text,
                    Address = address.Text,
                    PhoneNumber = phoneNumber.Text,
                    Email = email.Text,
                   
                };

                bool res = DependencyService.Get<ISQLite>().SaveEmployee(employee);
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
                // update employee
                Employee employeeDetails=new Employee();
                employeeDetails.Name = name.Text;
                employeeDetails.Address = address.Text;
                employeeDetails.PhoneNumber = phoneNumber.Text;
                employeeDetails.Email = email.Text;

                bool res = DependencyService.Get<ISQLite>().UpdateEmployee(employeeDetails);
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