
using STI_Finfo.Admin;
using STI_Finfo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();
            
            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
