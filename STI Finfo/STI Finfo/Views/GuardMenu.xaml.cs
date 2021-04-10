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
            
            // TEMPORARY LIST
            Request request1 = new Request
            {
                LastName = "Malinao",
                FirstName = "Malaboo",
                MiddleName = "D",

            };
            Request request2 = new Request
            {
                LastName = "Malinao",
                FirstName = "Malaboo",
                MiddleName = "D",



            };
            Request request3 = new Request
            {
                LastName = "Malinao",
                FirstName = "Malaboo",
                MiddleName = "D",



            };
            bool res = DependencyService.Get<ISQLite>().SaveRequest(request1);
            bool res1 = DependencyService.Get<ISQLite>().SaveRequest(request2);
            bool res3 = DependencyService.Get<ISQLite>().SaveRequest(request3);
            if (res & res1 & res3)
            {
                await Navigation.PushAsync(new TableRequest());
            }
        }
        private async void NoID_Clicked(object sender, EventArgs e)
        {

          
            
                await Navigation.PushAsync(new NoIDTable());
           
        }
    }
}