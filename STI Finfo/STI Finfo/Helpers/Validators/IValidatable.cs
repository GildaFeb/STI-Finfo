using System.Collections.Generic;
using System.ComponentModel;

namespace STI_Finfo.Helpers.Validators
{
    public interface IValidatable<T> : INotifyPropertyChanged
    {
        List<IValidationRule<T>> Validations { get; }

        List<string> Errors { get; set; }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        bool Validate();

        bool IsValid { get; set; }
    }
}
