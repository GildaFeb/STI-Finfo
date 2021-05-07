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

    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Model()
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
    public partial class Page2: ContentPage
    {

        List<Model> list = new List<Model>();
        public Page2()
        {
            InitializeComponent();

            this.BackgroundColor = Color.White;


            list.Add(new Model() { Text = "Front Desk" });
            list.Add(new Model() { Text = "Cashier" });
            list.Add(new Model() { Text = "Registrar" });
            list.Add(new Model() { Text = "Gymnasium" });
            list.Add(new Model() { Text = "Faculty" });
            list.Add(new Model() { Text = "Computer laboratory" });
            list.Add(new Model() { Text = "Kitchen laboratory" });
            list.Add(new Model() { Text = "Chemistry laboratory" });
            list.Add(new Model() { Text = "Canteen" });
            list.Add(new Model() { Text = "Lobby" });
            list.Add(new Model() { Text = "Student Library" });
            list.Add(new Model() { Text = "Student Lounge" });
            list.Add(new Model() { Text = "Guidance Office" });
            list.Add(new Model() { Text = "Principal's Office" });
            list.Add(new Model() { Text = "First Floor: Classrom" });
            list.Add(new Model() { Text = "Second Floor: Classrom" });
            listView.ItemsSource = list;
            return;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopAsync(true);
            var result = list.Where(w => w.IsChecked == true).ToList();

            string s = "";

            int index = 0;
            foreach (var model in result)
            {
                s = s + model.Text;
                if (index < result.Count - 1)
                {
                    s = s + ",";
                }
                index++;
            }

            MessagingCenter.Send<object, string>(this, "Hi", s);
            
        }
    }
}