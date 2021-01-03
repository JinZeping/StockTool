using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace WPFCommonExtension.ValidationRules
{
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return double.TryParse((value ?? "").ToString(), out double d) ? ValidationResult.ValidResult : new ValidationResult(false, "必须填入有效数字");
        }
    }
}
