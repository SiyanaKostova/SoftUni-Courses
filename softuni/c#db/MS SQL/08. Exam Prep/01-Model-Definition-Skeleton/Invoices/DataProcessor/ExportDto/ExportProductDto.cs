using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public CategoryType Category { get; set; }

        public ExportClientDto[] Clients { get; set; }
    }
}
