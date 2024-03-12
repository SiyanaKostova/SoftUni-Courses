using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportMedicineDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [XmlElement("ProductionDate")]
        [Required]
        public string ProductionDate { get; set; } 

        [XmlElement("ExpiryDate")]
        [Required]
        public string ExpiryDate { get; set; } 

        [XmlElement("Producer")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Producer { get; set; }

        [XmlAttribute("category")]
        [Required]
        public int Category { get; set; }
    }
}