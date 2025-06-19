using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public static class StringToEnumValueConverter<TEnum> where TEnum : struct
    {
        public static TEnum ConvertStringToEnum(string value)
        {
            if(value is null)
                throw new ArgumentNullException("value");

            Enum.TryParse<TEnum>(value, true, out TEnum enumValue);

            return enumValue;
        }
    }
}
