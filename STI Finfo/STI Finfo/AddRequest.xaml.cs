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
            var saveBtn = this.FindByName<Button>("saveBtn");
            var name = this.FindByName<Entry>("name");
            var address = this.FindByName<Entry>("address");
            var email = this.FindByName<Entry>("email");
            var password = this.FindByName<Entry>("password");
            var phoneNumber = this.FindByName<Entry>("phoneNumber");
            name.Text = details.Name;
            address.Text = details.Address;
            phoneNumber.Text = details.PhoneNumber;
            email.Text = details.Email;
            password.Text = details.Password;
            password.IsEnabled = false;
            saveBtn.Text = "Update";
            this.Title = "Edit Employee";
        }

        private void SaveEmployee(object sender, EventArgs e)
        {
            var saveBtn = this.FindByName<Button>("saveBtn");
            if (saveBtn.Text == "Save")
            {

                var name = this.FindByName<Entry>("name");
                var address = this.FindByName<Entry>("address");
                var email = this.FindByName<Entry>("email");
                var password = this.FindByName<Entry>("password");
                var phoneNumber = this.FindByName<Entry>("phoneNumber");
                Employee employee = new Employee
                {
                    Name = name.Text,
                    Address = address.Text,
                    PhoneNumber = phoneNumber.Text,
                    Email = email.Text,
                    Password = password.Text
                };

                bool res = DependencyService.Get<ISQLite>().SaveEmployee(employee);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Save", "Ok");
                }
            }
            else
            {

                var name = this.FindByName<Entry>("name");
                var address = this.FindByName<Entry>("address");
                var email = this.FindByName<Entry>("email");
                var phoneNumber = this.FindByName<Entry>("phoneNumber");
                // update employee
                Employee EmployeeDetails = new Employee
                {
                    Name = name.Text,
                    Address = address.Text,
                    PhoneNumber = phoneNumber.Text,
                    Email = email.Text
                };

                bool res = DependencyService.Get<ISQLite>().UpdateEmployee(EmployeeDetails);
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