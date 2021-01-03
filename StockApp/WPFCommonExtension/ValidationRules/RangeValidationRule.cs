using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace WPFCommonExtension.ValidationRules
{
    public class RangeValidationRule : ValidationRule
    {
        public double? Min { get; set; }
        public double? Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(!double.TryParse((value ?? "").ToString(), out double d))
            {
                return ValidationResult.ValidResult;
            }

            if (Min != null)
            {
                if (d < Min.Value)
                {
                    return new ValidationResult(false, $"输入数值不能小于{Min}");
                }
            }

            if (Max != null)
            {
                if (d > Max.Value)
                {
                    return new ValidationResult(false, $"输入数值不能大于{Max}");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
