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

            public ObservableCollection<NoID> NoID_Details { get; set; }
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
                    Day = "Today (3)",
                    CollImage="down2.png",
                    ExpImage="down3.png",
                  
                    IsVisible = false,
                     NoID_Details= new ObservableCollection<NoID>
                    {
                        new NoID
                        {
                             StudentNumber="02000176962", Account="Iwanha.02000176962@sjdelmonte.sti.edu.ph", Reasons="I forgot to bring my ID", DateNoID="April 12,2020 12:23:03"
                        },
                         new NoID
                        {
                              StudentNumber="02000453524", Account="Ressy.020003524@sjdelmonte.sti.edu.ph", Reasons="I accidentally throw my ID to trashbin",DateNoID="April 12,2020 13:45:13"
                        },
                          new NoID
                        {
                              StudentNumber="02000562436", Account="Napol.02000562436", Reasons="I do not know where I put my ID",DateNoID="April 12,2020 14:59:03"
                        }
                    }
                },
                new List
                {
                    Day = "Yesterday (5)",
                     CollImage="down2.png",
                    ExpImage="down3.png",
                    IsVisible = false,
                     NoID_Details= new ObservableCollection<NoID>
                    {
                       new NoID
                        {
                             StudentNumber="Park Bomi", Account="Cahier", Reasons="Pay tuition", DateNoID="April 12, 2020 12:23:03 - 15:40:33"
                        },
                         new NoID
                        {
                              StudentNumber="Kim Chorong", Account="Registrar", Reasons="Pass requirements",DateNoID="April 12, 2020 13:45:13 - 19:09:22"
                        },
                          new NoID
                        {
                              StudentNumber="Naeun Kim", Account="Faculty", Reasons="Pass requirements",DateNoID="April 12, 2020 14:59:03 - 19:25:22"
                        },
                          new NoID
                        {
                              StudentNumber="Jackson Wang", Account="Front desk", Reasons="Inquire",DateNoID="April 12, 2020 13:45:13 - 20:09:62"
                        },
                          new NoID
                        {
                              StudentNumber="Aeilee Amy", Account="Tatok.982436@sjdelmonte.sti.edu.ph", Reasons="I accidentally broke my ID",DateNoID="April 12,2020 14:59:03 - 20:09:45"
                        }
                    }
                },
                new List
                {
                      CollImage="down2.png",
                    ExpImage="down3.png",
                    Day = "Last week (13)",
                    IsVisible = false,
                      NoID_Details= new ObservableCollection<NoID>
                    {
                        new NoID
                        {
                             StudentNumber="02000322262", Account="Efren.322262@sjdelmonte.sti.edu.ph", Reasons="I forgot to bring my ID", DateNoID="April 12,2020 12:23:03"
                        },
                         new NoID
                        {
                              StudentNumber="02000233524", Account="Vico.2324@sjdelmonte.sti.edu.ph", Reasons="My bag was snatched together with my ID",DateNoID="April 12,2020 13:45:13"
                        },
                          new NoID
                        {
                              StudentNumber="02000562432", Account="Llamez.562432@sjdelmonte.sti.edu.ph", Reasons="I do not know where I put my ID",DateNoID="April 12,2020 14:59:03"
                        },
                    }
                },
                 new List
                {
                     CollImage="down2.png",
                    ExpImage="down3.png",
                    Day = "Last Month (29)",
                    IsVisible = false,
                     NoID_Details= new ObservableCollection<NoID>
                    {
                        new NoID
                        {
                             StudentNumber="Anil", Account="wow", Reasons="I forgot to bring my ID"
                        },
                         new NoID
                        {
                              StudentNumber="Anil", Account="wow", Reasons="I forgot to bring my ID"
                        },
                          new NoID
                        {
                           StudentNumber="Anil", Account="wow", Reasons="I forgot to bring my ID"
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
