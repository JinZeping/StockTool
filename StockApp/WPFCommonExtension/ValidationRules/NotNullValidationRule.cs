using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace WPFCommonExtension.ValidationRules
{
    public class NotNullValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value == null ? new ValidationResult(false, "必须填入有效值") : ValidationResult.ValidResult;
        }
    }
}
