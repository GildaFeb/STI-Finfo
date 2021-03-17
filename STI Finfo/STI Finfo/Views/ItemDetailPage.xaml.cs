using STI_Finfo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace STI_Finfo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}