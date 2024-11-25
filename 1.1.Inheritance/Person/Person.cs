using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person;

public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public override string ToString()
    {
        return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}"; 
    }
}
