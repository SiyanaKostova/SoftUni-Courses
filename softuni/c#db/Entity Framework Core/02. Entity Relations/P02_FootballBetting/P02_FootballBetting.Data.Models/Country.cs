using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
