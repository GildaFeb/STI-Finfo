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
                LastName = "Cruz",
                FirstName = "Juan Jhon",
                MiddleName = "A.",
                Age="18",
                Number="09254358545"

            };
            Request request2 = new Request
            {
                LastName = "Mouse",
                FirstName = "Mickey",
                MiddleName = "S",
                Age = "19",
                Number = "09694558545"


            };
            Request request3 = new Request
            {
                LastName = "Malinao",
                FirstName = "Malaboo",
                MiddleName = "D",
                Age = "18",
                Number = "09699358545"


            };
            Request request4 = new Request
            {
                LastName = "Cruz",
                FirstName = "Juan Jhon",
                MiddleName = "A.",
                Age = "18",
                Number = "09254358545"

            };
            Request request5 = new Request
            {
                LastName = "Mouse",
                FirstName = "Mickey",
                MiddleName = "S",
                Age = "19",
                Number = "09694558545"


            };
            Request request6 = new Request
            {
                LastName = "Malinao",
                FirstName = "Malaboo",
                MiddleName = "D",
                Age = "18",
                Number = "09699358545"


            };
            bool res = DependencyService.Get<ISQLite>().SaveRequest(request1);
            bool res1 = DependencyService.Get<ISQLite>().SaveRequest(request2);
            bool res3 = DependencyService.Get<ISQLite>().SaveRequest(request3);
            bool res4 = DependencyService.Get<ISQLite>().SaveRequest(request4);
            bool res5 = DependencyService.Get<ISQLite>().SaveRequest(request5);
            bool res6 = DependencyService.Get<ISQLite>().SaveRequest(request6);
            if (res & res1 & res3 & res4 & res5 & res6)
            {
                await Navigation.PushAsync(new TableRequest());
            }
        }
        private async void NoID_Clicked(object sender, EventArgs e)
        {

            NoID request1 = new NoID
            {
                StudentNumber = "02000177629",
                Account = "porlas.177629@sjdelmonte.sti.edu.ph",
                Reasons = "Fell on the river",
               

            };
            NoID request2 = new NoID
            {
                StudentNumber = "02000177905",
                Account = "serfino.177905@sjdelmonte.sti.edu.ph",
                Reasons = "My bag together with my ID was snatched",


            };
            NoID request3 = new NoID
            {
                StudentNumber = "02000178336",
                Account = "adapon.178336@sjdelmonte.sti.edu.ph",
                Reasons = "My baby brother burned my ID",


            };
            NoID request4 = new NoID
            {
                StudentNumber = "02000177457",
                Account = "regalado.177457@sjdelmonte.sti.edu.ph",
                Reasons = "I forgot where I put my ID",

            };
            NoID request5 = new NoID
            {
                StudentNumber = "02000180175",
                Account = "ili.180175@sjdelmonte.sti.edu.ph",
                Reasons = "My mother accidentally throw my ID in the transh bin",

            };
            NoID request6 = new NoID
            {
                StudentNumber = "02000176925",
                Account = "lacanienta.176925@sjdelmonte.sti.edu.ph",
                Reasons = "I cannot find my ID",


            };
            bool res = DependencyService.Get<ISQLite>().SaveNoID(request1);
            bool res1 = DependencyService.Get<ISQLite>().SaveNoID(request2);
            bool res3 = DependencyService.Get<ISQLite>().SaveNoID(request3);
            bool res4 = DependencyService.Get<ISQLite>().SaveNoID(request4);
            bool res5 = DependencyService.Get<ISQLite>().SaveNoID(request5);
            bool res6 = DependencyService.Get<ISQLite>().SaveNoID(request6);
            if (res & res1 & res3 & res4 & res5 & res6)
            {
                await Navigation.PushAsync(new NoIDTable());
            }
          
           
        }
    }
}