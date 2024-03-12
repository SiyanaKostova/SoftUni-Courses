using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDto
    {
        [Required]
        [MaxLength(25)]
        [MinLength(10)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(10)]
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        public ImportAddressDto[] Addresses { get; set; }
    }
}

//< Client >
//    < Name > LiCB </ Name >
//    < NumberVat > BG5464156654654654 </ NumberVat >
//    < Addresses >
//      < Address >
//        < StreetName > Gnigler strasse </ StreetName >
//        < StreetNumber > 57 </ StreetNumber >
//        < PostCode > 5020 </ PostCode >
//        < City > Salzburg </ City >
//        < Country > Austria </ Country >
//      </ Address >
//    </ Addresses >
//  </ Client >