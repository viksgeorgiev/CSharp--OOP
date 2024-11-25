using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

public abstract class BaseHealingHero : BaseHero
{
    protected BaseHealingHero(string name, int power) 
        : base(name, power)
    {
    }

    public sealed override string CastAbility() => $"{this.GetType().Name} - {Name} healed for {Power}";
}
