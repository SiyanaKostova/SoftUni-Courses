using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ExportDto
{
    public class TeamExportDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Footballers")]
        public FootballerExportDto[] Footballers { get; set; }
    }
}
