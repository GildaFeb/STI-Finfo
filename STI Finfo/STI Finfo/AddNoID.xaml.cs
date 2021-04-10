﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STI_Finfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNoID : ContentPage
    {
        public AddNoID(NoID details)
        {
            InitializeComponent();
            if (details != null)
            {

                PopulateDetails(details);
            }


        }

        private void PopulateDetails(NoID details)
        {
            studentnumber.Text = details.StudentNumber;
            account.Text = details.Account;
            reasons.Text = details.Reasons;



            var save = this.FindByName<Button>("saveBtn");
            save.Text = "Update";
            this.Title = "Edit request";
        }

        private void SaveNoID(object sender, EventArgs e)
        {
            var save = this.FindByName<Button>("saveBtn");
            if (save.Text == "SUBMIT")
            {
                NoID requestss = new NoID
                {
                    StudentNumber = studentnumber.Text,
                    Account = account.Text,
                    Reasons = reasons.Text,

                };

                bool res = DependencyService.Get<ISQLite>() .SaveNoID(requestss);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Failed to save", "Okay");
                }
            }
            else
            {
                // update request
                NoID NoIDDetails = new NoID
                {
                    StudentNumber = studentnumber.Text,
                    Account = account.Text,
                    Reasons = reasons.Text,
                };

                bool res = DependencyService.Get<ISQLite>() .UpdateNoID(NoIDDetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data failed to update", "Okay");
                }
            }
        }

    }
}



