using Raiding.Interfaces.Factories;
using Raiding.Interfaces.Models;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories;

public class RogueFactory : IFactory
{
    public IHero Create(string name) => new Rogue(name);
   
}
