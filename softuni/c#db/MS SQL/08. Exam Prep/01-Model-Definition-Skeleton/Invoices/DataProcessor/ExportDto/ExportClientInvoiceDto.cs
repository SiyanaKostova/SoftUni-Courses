using Invoices.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientInvoiceDto
    {
        public string ClientName { get; set; }

        public string VatNumber { get; set; }

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        public ExportInvoiceDto[] Invoices { get; set; }
    }
}
