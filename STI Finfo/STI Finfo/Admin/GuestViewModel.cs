using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace STI_Finfo.Admin
{
    class GuestViewModel
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

            public ObservableCollection<AdminRequest> Request_Details { get; set; }
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

        public GuestViewModel()
        {
            ObservableCollection<AdminRequest> yesterday = new ObservableCollection<AdminRequest>((IEnumerable<AdminRequest>)DependencyService.Get<ISQLite>().GetGuestYesterday());
            ObservableCollection<AdminRequest> Today = new ObservableCollection<AdminRequest>((IEnumerable<AdminRequest>)DependencyService.Get<ISQLite>().GetGuestToday());
            Lists = new ObservableCollection<List>
            {
                new List
                {
                    Day = "Today (3)",
                    CollImage="down2.png",
                    ExpImage="down3.png",

                    IsVisible = false,
                    Request_Details= Today
                    

                 },

                 new List
                {
                    Day = "Yesterday (3)",
                    CollImage="down2.png",
                    ExpImage="down3.png",

                    IsVisible = false,
                    Request_Details= yesterday

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

