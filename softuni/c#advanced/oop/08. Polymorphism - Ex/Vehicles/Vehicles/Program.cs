using System;
using System.Reflection.PortableExecutable;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}