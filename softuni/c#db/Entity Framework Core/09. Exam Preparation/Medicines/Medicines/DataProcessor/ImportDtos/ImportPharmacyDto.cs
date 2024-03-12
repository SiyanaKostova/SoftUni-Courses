using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [XmlAttribute("non-stop")]
        [Required]
        public string NonStop { get; set; } 


        [XmlElement("Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }


        [XmlElement("PhoneNumber")]
        [Required]
        [MaxLength(14)]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }


        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public ImportMedicineDto[] Medicines { get; set; }
    }
}
