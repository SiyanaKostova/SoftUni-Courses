using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public ImportTrucksDto[] Trucks { get; set; }
    }
}
