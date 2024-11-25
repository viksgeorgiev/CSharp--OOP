using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models;

public abstract class BaseHittingHero : BaseHero
{
    protected BaseHittingHero(string name, int power) 
        : base(name, power)
    {
    }

    public sealed override string CastAbility() => $"{this.GetType().Name} - {Name} hit for {Power} damage";
}
