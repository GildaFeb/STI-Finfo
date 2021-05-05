using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace STI_Finfo.Admin
{
    public class MainViewModel

    {
        public class List
        {
            private string expImage;

            public string GetExpImage()
            {
                return expImage;
            }

            public void SetExpImage(string value)
            {
                expImage = value;
            }

            public ObservableCollection<AdminNoID> NoID_Details { get; set; }
            public string Day { get; set; }
            public bool IsVisible { get; set; }
            public string CollImage { get; set; }
            public string ExpImage { get; set; }
        }
        public class ProductDetails
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private List _oldList;
        public ObservableCollection<List> Lists { get; set; }

        public MainViewModel()
        {
            ObservableCollection<AdminNoID> adminNoIDs = new ObservableCollection<AdminNoID>((IEnumerable<AdminNoID>)DependencyService.Get<ISQLite>().AdminGetNoID());
            Lists = new ObservableCollection<List>
            {
                new List
                {
                    Day = "Today (3)",
                    CollImage="down2.png",
                    ExpImage="down3.png",

                    IsVisible = false,
                    NoID_Details= adminNoIDs


                 },

            };
   
        }

        public void ShoworHiddenProducts(List list)
        {
            if (_oldList == list)
            {
                list.IsVisible = !list.IsVisible;
                UpDateProducts(list);
            }
            else
            {
                if (_oldList != null)
                {
                    _oldList.IsVisible = false;
                    UpDateProducts(_oldList);

                }
                list.IsVisible = true;
                UpDateProducts(list);
            }
            _oldList = list;
        }

        private void UpDateProducts(List product)
        {
            var Index = Lists.IndexOf(product);
            Lists.Remove(product);
            Lists.Insert(Index, product);

        }
    }


}
