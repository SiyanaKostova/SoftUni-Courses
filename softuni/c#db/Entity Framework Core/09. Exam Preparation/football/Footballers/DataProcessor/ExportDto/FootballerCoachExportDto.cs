using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    public class FootballerCoachExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string PositionType { get; set; }
    }
}
