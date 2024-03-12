using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{

    [XmlType("Coach")]
    public class CoachExportDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount;

        [XmlElement("CoachName")]
        public string Name { get; set; }

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public List<FootballerCoachExportDto> Footballers { get; set; }
    }

}
