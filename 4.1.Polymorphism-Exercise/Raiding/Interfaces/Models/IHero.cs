using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Interfaces.Models;

public interface IHero
{
    public string  Name { get; }
    public int Power { get; }

    string CastAbility();
}
