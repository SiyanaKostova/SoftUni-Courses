using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ExportDto
{
    public class FootballerExportDto
    {
        [JsonProperty("FootballerName")]
        public string FootballerName { get; set; }

        [JsonProperty("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [JsonProperty("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [JsonProperty("BestSkillType")]
        public string BestSkillType { get; set; }

        [JsonProperty("PositionType")]
        public string PositionType { get; set; }
    }
}
