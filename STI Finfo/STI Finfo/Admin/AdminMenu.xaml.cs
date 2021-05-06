using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMenu : ContentPage
    {
        public AdminMenu()
        {
            InitializeComponent();
        }
        public async void NoID_Admin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new ListviewDetails());
        }

        private async void Guest_Admin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuestAdmin());
        }
    }
}