namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Helpers;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creatorsDto = XmlSerializationHelper.Deserialize<ImportCreatorsDto[]>(xmlString, "Creators");

            StringBuilder sb = new StringBuilder();

            List<Creator> creatorList = new List<Creator>();

            foreach (var creatorDto in creatorsDto)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    creator.Boardgames.Add(new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    });
                }

                creatorList.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count()));
            }

            context.Creators.AddRange(creatorList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            List<Seller> sellerList = new List<Seller>();

            var uniqueBoardgameIds = context.Boardgames.Select(bg => bg.Id).ToArray();

            foreach (ImportSellerDto sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var boardgameId in sellerDto.BoardgamesIDs.Distinct())
                {
                    if (!uniqueBoardgameIds.Contains(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller bgs = new BoardgameSeller
                    {
                        Seller = seller,
                        BoardgameId = boardgameId,
                    };

                    seller.BoardgamesSellers.Add(bgs);
                }

                sellerList.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
            }

            context.AddRange(sellerList);
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
