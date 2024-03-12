using Newtonsoft.Json;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportPharmacyDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}