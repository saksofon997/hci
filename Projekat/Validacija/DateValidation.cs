using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekat.Validacija
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string regexError = "Primer datuma: 13/12/1967, 4/1/2001";
            Regex regex = new Regex(@"^\d{1,2}\/\d{1,2}\/\d{4}$");
            try
            {
                var uid = value as string;

                if (!regex.IsMatch(uid))
                {
                    return new ValidationResult(false, regexError);
                }

                return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Unknown error.");
            }
        }
    }
}
