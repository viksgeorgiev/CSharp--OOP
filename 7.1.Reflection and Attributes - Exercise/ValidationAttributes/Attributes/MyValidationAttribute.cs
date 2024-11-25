using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;
[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
public abstract class MyValidationAttribute : Attribute
{
    public abstract bool IsValid(object obj);
}
