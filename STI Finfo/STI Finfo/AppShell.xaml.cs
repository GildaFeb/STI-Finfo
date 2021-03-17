using STI_Finfo.ViewModels;
using STI_Finfo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace STI_Finfo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
