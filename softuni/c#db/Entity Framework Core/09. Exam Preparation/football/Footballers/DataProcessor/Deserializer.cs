namespace Footballers.DataProcessor
{
    using Castle.Core.Internal;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Helpers;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var coachesDto = XmlSerializationHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");       

            StringBuilder sb = new StringBuilder();

            List<Coach> coachesList = new List<Coach>();

            foreach (var coachDto in coachesDto)
            {
                if ((!IsValid(coachDto)) || (!IsValid(coachDto.Nationality)) || (coachDto.Nationality.IsNullOrEmpty()))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if ((!IsValid(footballerDto)) 
                        || footballerDto.ContractStartDate > footballerDto.ContractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = DateTime.ParseExact(footballerDto.ContractStartDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ContractEndDate = DateTime.ParseExact(footballerDto.ContractEndDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    });
                }

                coachesList.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count()));
            }

            context.Coaches.AddRange(coachesList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var teamsDtos = JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString);

            List<Team> teamsList = new List<Team>();

            var uniqueFootballersIds = context.Footballers.Select(x => x.Id).ToArray();

            foreach (ImportTeamsDto teamDto in teamsDtos)
            {
                if ((!IsValid(teamDto)) || teamDto.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };

                foreach (var footballerID in teamDto.FootballerIds.Distinct())
                {
                    if (!uniqueFootballersIds.Contains(footballerID))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer f = context.Footballers.Find(footballerID);

                    if (f == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerID
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }
                teamsList.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count()));
            }

            context.AddRange(teamsList);
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
