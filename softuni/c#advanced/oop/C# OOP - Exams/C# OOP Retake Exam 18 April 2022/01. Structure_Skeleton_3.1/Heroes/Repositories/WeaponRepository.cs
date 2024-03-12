using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void Add(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) => models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IWeapon model) => models.Remove(model);
    }
}
