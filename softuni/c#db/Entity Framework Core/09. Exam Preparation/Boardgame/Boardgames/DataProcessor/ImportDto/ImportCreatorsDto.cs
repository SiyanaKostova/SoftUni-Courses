using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorsDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardgameDto[] Boardgames { get; set; }
    }
}

//•	FirstName – text with length [2, 7] (required)
//•	LastName – text with length [2, 7] (required)
//•	Boardgames – collection of type Boardgame
