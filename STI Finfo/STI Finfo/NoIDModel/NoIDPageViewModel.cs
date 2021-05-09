using System;
using System.ComponentModel;
using System.Windows.Input;
using STI_Finfo.Helpers.Validators;
using STI_Finfo.Helpers.Validators.Rules;
using Xamarin.Forms;

namespace STI_Finfo.NoIDModel { 
    public class NoIDPageViewModel : NoIDPageViewModelBase, INotifyPropertyChanged
    {
        public ValidatableObject<string> Reasons { get; set; } = new ValidatableObject<string>();
         public ValidatableObject<string> StudentNumber { get; set; } = new ValidatableObject<string>();
        public ValidatablePair<string> Account { get; set; } = new ValidatablePair<string>();
       

        public NoIDPageViewModel()
        {
            AddValidationRules();
        }

        public void AddValidationRules()
        {
            Reasons.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Reason is Required" });
            StudentNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Student Number Required" });
            StudentNumber.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "Student Number should have a maximun of 10 digits and minimun of 8", MaximunLenght = 10, MinimunLenght = 8 });

            //Email Validation Rules
            Account.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Account.Item1.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
          
           
           
        }


        public ICommand SignUpCommand => new Command(async () =>
        {
            if (AreFieldsValid())
            {
                await Application.Current.MainPage.DisplayAlert("Welcome", "", "Ok");
            }
        });

        bool AreFieldsValid()
        {
            bool isFirstNameValid = Account.Validate();
            bool isLastNameValid = Reasons.Validate();
            bool isBirthDayValid = StudentNumber.Validate();


            return isFirstNameValid && isLastNameValid && isBirthDayValid;
        }
    }
}
