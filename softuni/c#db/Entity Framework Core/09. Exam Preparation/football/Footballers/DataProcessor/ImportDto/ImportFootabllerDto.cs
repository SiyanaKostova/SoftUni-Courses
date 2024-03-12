using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootabllerDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDateString { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDateString { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        public int PositionType { get; set; }

        [XmlIgnore]
        public DateTime ContractStartDate => DateTime.ParseExact(this.ContractStartDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        [XmlIgnore]
        public DateTime ContractEndDate => DateTime.ParseExact(this.ContractEndDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
