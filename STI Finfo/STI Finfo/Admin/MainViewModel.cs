using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace STI_Finfo.Admin
{
    public class MainViewModel
    {
        public  ObservableCollection<Lists> ListItems;

        
        public MainViewModel()
        {
            ListItems = new ObservableCollection<Lists>
            {
                new Lists
                {

                    Title="Todayyy",
                  
                    IsVisible= false,

                },
                 new Lists
                {

                    Title="Yesterday",

                },
                  new Lists
                {

                    Title="Last week",

                    

                }
            };

        }
        public Lists _oldLists;



        public void HideOrShowList(Lists list)
        {
            
            if (_oldLists == list)
            {
                // HIDE CLICK TWICE
                list.IsVisible = !list.IsVisible;
                UpdateLists(list);


            }
            else
            {

                if (_oldLists != null)
                {
                    // HIDE PREVIEW ITEM
                    _oldLists.IsVisible = false;
                    UpdateLists(list);
                }
            }
            list.IsVisible = true;
            UpdateLists(list);
        }

        private void UpdateLists(Lists list)
        {
            var index = ListItems.IndexOf(list);
            ListItems.Remove(list);
            ListItems.Insert(index,list);
        }


       
    }
}
