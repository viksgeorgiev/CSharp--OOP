using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

public class Paladin : BaseHealingHero
{
    private const int StartingPower = 100;

    public Paladin(string name) 
        : base(name, StartingPower)
    {
    }
}
