using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

public class Warrior : BaseHittingHero
{
    private const int StartingPower = 100;
    public Warrior(string name) 
        : base(name, StartingPower)
    {
    }
}
