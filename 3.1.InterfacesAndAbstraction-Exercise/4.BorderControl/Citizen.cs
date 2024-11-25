using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BorderControl
{
    public class Citizen : IIdentifiable, INameable, IAgeable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get;}      
        public int Age { get;  }
        public string Id { get; }

        public string Birthdate { get; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
