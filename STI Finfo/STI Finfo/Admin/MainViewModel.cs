using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


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

            public ObservableCollection<ProductDetails> Product_Details { get; set; }
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
            Lists = new ObservableCollection<List>
            {
                new List
                {
                    Day = "Today",
                    CollImage="down2.png",
                    ExpImage="down3.png",
                  
                    IsVisible = false,
                      Product_Details= new ObservableCollection<ProductDetails>
                    {
                        new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                         new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                          new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        }
                    }
                },
                new List
                {
                    Day = "Yesterday",
                     CollImage="down2.png",
                    ExpImage="down3.png",
                    IsVisible = false,
                      Product_Details= new ObservableCollection<ProductDetails>
                    {
                        new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                         new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                          new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        }
                    }
                },
                new List
                {
                      CollImage="down2.png",
                    ExpImage="down3.png",
                    Day = "Last week",
                    IsVisible = false,
                      Product_Details= new ObservableCollection<ProductDetails>
                    {
                        new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                         new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                          new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        }
                    }
                },
                 new List
                {
                     CollImage="down2.png",
                    ExpImage="down3.png",
                    Day = "Last Month",
                    IsVisible = false,
                      Product_Details= new ObservableCollection<ProductDetails>
                    {
                        new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                         new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        },
                          new ProductDetails
                        {
                            Key="Anil", Value="wow"
                        }
                    }
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
