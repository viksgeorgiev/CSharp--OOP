using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

public class Druid : BaseHealingHero
{
    private const int StartingPower = 80;

    public Druid(string name) 
        : base(name, StartingPower)
    {
    }
}
