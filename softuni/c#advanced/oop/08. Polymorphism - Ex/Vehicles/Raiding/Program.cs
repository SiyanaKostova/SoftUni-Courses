using Raiding.Factories.Interfaces;
using Raiding.Factories;
using System;
using Raiding.IO.Interfaces;
using Raiding.IO;
using Raiding.Core;
using Raiding.Core.Interfaces;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);
            engine.Run();
        }
    }
}