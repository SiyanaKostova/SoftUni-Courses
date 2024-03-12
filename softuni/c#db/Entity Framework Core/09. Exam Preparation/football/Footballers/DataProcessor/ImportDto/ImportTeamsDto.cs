using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9 .-]+$")]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballerIds { get; set; }
    }
}
