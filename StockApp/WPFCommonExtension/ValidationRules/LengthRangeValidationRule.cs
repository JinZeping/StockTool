using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace WPFCommonExtension.ValidationRules
{
    public class LengthRangeValidationRule : ValidationRule
    {
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (value ?? "").ToString();

            if (MinLength != null)
            {
                if (s.Length < MinLength.Value)
                {
                    return new ValidationResult(false, $"输入内容长度不能小于{MinLength}");
                }
            }

            if (MaxLength != null)
            {
                if (s.Length > MaxLength.Value)
                {
                    return new ValidationResult(false, $"输入内容长度不能大于{MaxLength}");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
