using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : BaseHittingHero
    {
        private const int StartingPower = 80;
        public Rogue(string name) 
            : base(name, StartingPower)
        {
        }
    }
}
