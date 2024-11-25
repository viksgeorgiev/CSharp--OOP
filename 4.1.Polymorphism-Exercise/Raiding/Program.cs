using System;
using System.Collections.Generic;
using Raiding.Factories;
using Raiding.Interfaces.Factories;
using Raiding.Interfaces.Models;

namespace Raiding;

public class Program
{
    public static void Main()
    {
        var factories = new Dictionary<string, IFactory> { ["Druid"] = new DruidFactory(), ["Paladin"] = new PaladinFactory(), ["Rogue"] = new RogueFactory(), ["Warrior"] = new WarriorFactory() };
        var heroes = new List<IHero>();

        int linesN = int.Parse(Console.ReadLine());

        while (heroes.Count < linesN)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            if (factories.TryGetValue(heroType, out var factory)) heroes.Add(factory.Create(heroName));
            else Console.WriteLine("Invalid hero!");
        }

        int bossPower = int.Parse(Console.ReadLine());
        int raidPower = 0;
        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());
            raidPower += hero.Power;
        }

        if(raidPower >= bossPower)
        {
            Console.WriteLine("Victory!");
        }
        else
        {
            Console.WriteLine("Defeat...");
        }
    }
}
