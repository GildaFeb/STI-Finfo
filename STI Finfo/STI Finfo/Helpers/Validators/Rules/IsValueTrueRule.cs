using System;
using System.Collections.Generic;
using System.Text;

namespace STI_Finfo.Helpers.Validators.Rules
{
    public class IsValueTrueRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            return bool.Parse($"{value}");
        }
    }
}
