using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] property = type.GetProperties();

            PropertyInfo[] propertiesWithCustomAttributes = type.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit: true))
                .ToArray();

            foreach (var propertyInfo in propertiesWithCustomAttributes)
            {
                var validationAttributes = propertyInfo
                    .GetCustomAttributes(typeof(MyValidationAttribute), inherit: true)
                    .Cast<MyValidationAttribute>();
                object value = propertyInfo.GetValue(obj);
                foreach (var attribute in validationAttributes)
                {                  
                    if (!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
