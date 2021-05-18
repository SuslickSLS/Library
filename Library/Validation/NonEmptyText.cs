using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library.Validation
{
    class NonEmptyTextRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            if (value as string != null || value as string != "")
            {
                string text = value as string;
                if (text.Trim() != "")
                {
                    if(text.Length > MinimumCharacters)
                    {
                        return ValidationResult.ValidResult;
                    }
                    return new ValidationResult(false, $"Строка должна содержать {MinimumCharacters} символов");
                }
            }
            return new ValidationResult(false, "Занчение не может быть пустым или состоять из пробелов");
        }
    }
}
