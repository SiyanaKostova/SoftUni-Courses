namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Helpers;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var despatchersDto = XmlSerializationHelper.Deserialize<ImportDespatchersDto[]>(xmlString, "Despatchers");

            StringBuilder sb = new StringBuilder();

            List<Despatcher> despatchersList = new List<Despatcher>();

            foreach (var depatcherDto in despatchersDto)
            {
                if (!IsValid(depatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = depatcherDto.Name,
                    Position = depatcherDto.Position
                };

                if (despatcher.Position is null || despatcher.Position == string.Empty)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var truckDto in depatcherDto.Trucks.Distinct())
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    despatcher.Trucks.Add(new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    });
                }
                despatchersList.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count()));
            }

            context.Despatchers.AddRange(despatchersList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var clientsDtos = JsonConvert.DeserializeObject<ImportClientsDto[]>(jsonString);

            List<Client> clientsList = new List<Client>();

            var uniqueTruckIds = context.Trucks.Select(t => t.Id).ToArray();

            foreach (ImportClientsDto clientDto in clientsDtos.Distinct())
            {
                if ((!IsValid(clientDto)) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.TrucksIds.Distinct())
                {
                    if (!uniqueTruckIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId,
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                clientsList.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count()));
            }

            context.AddRange(clientsList);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}