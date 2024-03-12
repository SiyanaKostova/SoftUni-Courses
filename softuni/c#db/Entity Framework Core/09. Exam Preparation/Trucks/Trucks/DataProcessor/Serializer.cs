namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Helpers;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(c => new ExportDespatcherDto()
                {
                    Name = c.Name,
                    TrucksCount = c.Trucks.Count(),
                    Trucks = c.Trucks
                        .Select(t => new ExportDespatcherTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                }).OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.Name)
                .ToArray(); 

            return XmlSerializationHelper.Serialize(despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context
               .Clients
               .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
               .ToArray()
               .Select(c => new
               {
                   c.Name,
                   Trucks = c.ClientsTrucks
                       .Where(ct => ct.Truck.TankCapacity >= capacity)
                       .ToArray()
                       .OrderBy(ct => ct.Truck.MakeType.ToString())
                       .ThenByDescending(ct => ct.Truck.CargoCapacity)
                       .Select(ct => new
                       {
                           TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                           VinNumber = ct.Truck.VinNumber,
                           TankCapacity = ct.Truck.TankCapacity,
                           CargoCapacity = ct.Truck.CargoCapacity,
                           CategoryType = ct.Truck.CategoryType.ToString(),
                           MakeType = ct.Truck.MakeType.ToString()
                       })
                       .ToArray()
               })
               .OrderByDescending(c => c.Trucks.Length)
               .ThenBy(c => c.Name)
               .Take(10)
               .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
