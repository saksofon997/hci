using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekat.Validacija
{
    public class NameValidation : ValidationRule
    {
        private bool isDuplicate(string uid)
        {
            var tagList = MainWindow.Tipovi;
            var resList = MainWindow.Resursi;
            return tagList.Any(tag => tag.Oznaka == uid) || resList.Any(tag => tag.Oznaka == uid);
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string requiredError = "Obavezno polje";
            string regexError = "Dozvoljena su samo slova, brojevi i razmaci.";
            Regex regex = new Regex(@"^[šŠđĐčČćĆžŽa-zA-Z0-9_' ']+$");
            try
            {
                var uid = value as string;
                if (String.IsNullOrWhiteSpace(uid))
                {
                    return new ValidationResult(false, requiredError);
                }

                if (!regex.IsMatch(uid))
                {
                    return new ValidationResult(false, regexError);
                }

                if (isDuplicate(uid))
                {
                    return new ValidationResult(false, "Oznaka već postoji");
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
