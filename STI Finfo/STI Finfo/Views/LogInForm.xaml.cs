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
            await Navigation.PushAsync(new GuardMenu());
        }
    }
}