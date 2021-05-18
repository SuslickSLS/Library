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
    class AddressValidationRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Trim() != "")
            {
                if (!Regex.IsMatch(value.ToString(), @"[А-Яа-я]{4,100},[1-9][0-9]"))
                {
                    return new ValidationResult(false, "Адрес введен не верно!\n Пример: Примерова,20");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
