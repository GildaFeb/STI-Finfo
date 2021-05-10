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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
          

        }
        private async void GuestButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMenu());
        }
        private async void SecurityButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInForm());
        }
        private async void NoIDButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuardMenu());
        }
        
        
    }
}