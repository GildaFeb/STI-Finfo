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
    public partial class NoIDForm : ContentPage
    {
        public NoIDForm()
        {
            InitializeComponent();
        }

        
        private void SaveNoID(object sender, EventArgs e)
        {
            

            this.Title = "GUEST FORM";
            var save = this.FindByName<Button>("submit");
            var StudentNo = this.FindByName<Entry>("studentnumber");
            var Accounts = this.FindByName<Entry>("account");
            var Reasons = this.FindByName<Entry>("reasons");
            if (save.Text == "SUBMIT")
            {

                NoID requestss = new NoID
                {
                    StudentNumber = StudentNo.Text,
                    Account = Accounts.Text,
                    Reasons = Reasons.Text,

                };

                bool res = DependencyService.Get<ISQLite>().SaveNoID(requestss);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Failed to save", "Okay");
                }
            }
        }
    }
}