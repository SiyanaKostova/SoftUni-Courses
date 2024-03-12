using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class ExportSalesPerCustomerDTO
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }
        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
