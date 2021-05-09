using STI_Finfo.Admin;
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
    public partial class LogInForm : ContentPage
    {
        public LogInForm()
        {
            InitializeComponent();
         
        }
        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            var username = this.FindByName<Entry>("username");
            var password = this.FindByName<Entry>("password");
            string staffUsername = username.Text;
            string staffPassword = password.Text;
            if (username == null || password == null)
            {
                await DisplayAlert("Alert", "Please enter username and password", "okay");
            }
            else if (staffUsername == "staff" && staffPassword == "staff5vcb2")
            {
                await DisplayAlert("Message", "Log in successfully", "okay");
                await Navigation.PushAsync(new GuardMenu());
            }
            else if (staffUsername == "Admin" && staffPassword == "Admin54xcvz")
            {
                await DisplayAlert("Message", "Log in successfully", "okay");
                await Navigation.PushAsync(new AdminMenu());
            }
            else if (staffUsername != "staff" || staffPassword != "staff5vcb2")
            {
                await DisplayAlert("Alert", "Username or password is not correct.", "okay");
            }
            else if (staffUsername != "Adminfx21" || staffPassword != "Admin54xcvz")
            {
                await DisplayAlert("Alert", "Username or password is not correct.", "okay");
            }
        }
    }
}