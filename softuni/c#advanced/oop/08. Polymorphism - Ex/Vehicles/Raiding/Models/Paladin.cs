using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int DefaultPower = 100;
        public Paladin(string name) : base(name, DefaultPower)
        {
        }

        public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
