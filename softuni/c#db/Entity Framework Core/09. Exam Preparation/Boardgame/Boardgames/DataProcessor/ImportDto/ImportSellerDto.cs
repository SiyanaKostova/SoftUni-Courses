using Boardgames.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Required]
        [JsonProperty("Website")]
        [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.com$")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] BoardgamesIDs { get; set; }
    }
}

//{
//    "Name": "6am",
//    "Address": "The Netherlands",
//    "Country": "Belgium",
//		"Website": "www.6pm.com",
//    "Boardgames": [

//            1,
//			105,
//			1,
//			5,
//			15
//    ]
//  },
