namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Helpers;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
             .Where(c => c.Footballers.Any())
             .Select(c => new CoachExportDto
             {
                 Name = c.Name,
                 FootballersCount = c.Footballers.Count(),
                 Footballers = c.Footballers
                     .OrderBy(f => f.Name)
                     .Select(f => new FootballerCoachExportDto
                     {
                         Name = f.Name,
                         PositionType = f.PositionType.ToString()
                     })
                     .ToList()
             })
             .OrderByDescending(c => c.Footballers.Count())
             .ThenBy(c => c.Name)
             .ToList();

            return XmlSerializationHelper.Serialize(coaches, "Coaches");
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        { 
            var teams = context
            .Teams
            .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
            .ToArray()
            .Select(t => new
            {
                t.Name,
                Footballers = t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .ToArray()
                    .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                    .ThenBy(tf => tf.Footballer.Name)
                    .Select(tf => new
                    {
                        FootballerName = tf.Footballer.Name,
                        ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = tf.Footballer.BestSkillType.ToString(),
                        PositionType = tf.Footballer.PositionType.ToString()
                    })
                    .ToArray()
            })
            .OrderByDescending(t => t.Footballers.Length)
            .ThenBy(t => t.Name)
            .Take(5)
            .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
