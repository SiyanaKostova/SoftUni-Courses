using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientsDto
    {
        [JsonProperty("Name")]
        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Nationality { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }

        [JsonProperty("Trucks")]
        public int[] TrucksIds { get; set; }
    }
}
