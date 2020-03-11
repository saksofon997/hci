using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekat.Validacija
{
    public class PriceValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var s = value as string;
            int i;
            if (int.TryParse(s, out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Unesite validnu cenu");
        }
    }
}
