using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo
{

    public class Models : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Models()
        {
            IsChecked = false;
        }

        public string Text { get; set; }

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                NotifyPropertyChanged();
            }
        }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopAdd : ContentPage
    {

        List<Models> list = new List<Models>();
        public PopAdd()
        {
            InitializeComponent();

            this.BackgroundColor = Color.White;

            var lists = this.FindByName<ListView>("listView");
            list.Add(new Models() { Text = " Front Desk" });
            list.Add(new Models() { Text = " Cashier" });
            list.Add(new Models() { Text = " Registrar" });
            list.Add(new Models() { Text = " Gymnasium" });
            list.Add(new Models() { Text = " Faculty" });
            list.Add(new Models() { Text = " Computer laboratory" });
            list.Add(new Models() { Text = " Kitchen laboratory" });
            list.Add(new Models() { Text = " Chemistry laboratory" });
            list.Add(new Models() { Text = " Canteen" });
            list.Add(new Models() { Text = " Lobby" });
            list.Add(new Models() { Text = " Student Library" });
            list.Add(new Models() { Text = " Student Lounge" });
            list.Add(new Models() { Text = " Guidance Office" });
            list.Add(new Models() { Text = " Principal's Office" });
            list.Add(new Models() { Text = " First Floor: Classrom" });
            list.Add(new Models() { Text = " Second Floor: Classrom" });
            lists.ItemsSource = list;
            return;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            
            var result = list.Where(w => w.IsChecked == true).ToList();

            string s = "";

            int index = 0;
            foreach (var models in result)
            {
                s = s + models.Text;
                if (index < result.Count - 1)
                {
                    s = s + ",";
                }
                index++;
            }

            MessagingCenter.Send<object, string>(this, " ", s);
            await Navigation.PopAsync();
        }
    }
}