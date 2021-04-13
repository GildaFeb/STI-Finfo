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
    public partial class GuardMenu : ContentPage
    {
        public GuardMenu()
        {
            InitializeComponent();
              
        }
        
        private async void Guest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TableRequest());
        }
        private async void NoID_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new NoIDTable());
            
        }
    }
}