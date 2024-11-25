﻿using CommandPattern.Core.CommandInterpreter;
using CommandPattern.Core.Contracts;
using CommandPattern.Core.Engine;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
