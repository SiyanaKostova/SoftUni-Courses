using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicineDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Pharmacy")]
        public ExportPharmacyDto Pharmacy { get; set; }
    }
}
