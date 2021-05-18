using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library.Validation
{
    class PhoneValidationRules: ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Trim() != "")
            {
                if (!Regex.IsMatch(value.ToString(), @"8\d{10}"))
                {
                    return new ValidationResult(false, "Телефон введен не верно!\n Пример 89002001030");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
