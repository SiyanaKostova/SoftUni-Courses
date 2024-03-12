using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository()
        {
            models = new List<ISubject>();
        }
        private readonly List<ISubject> models;
        public IReadOnlyCollection<ISubject> Models => models;

        public void AddModel(ISubject model)
        {
            ISubject subject = null;

            if (model is TechnicalSubject)
            {
                subject = new TechnicalSubject(models.Count + 1, model.Name);
            }
            if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(models.Count + 1, model.Name);
            }
            if (model is HumanitySubject)
            {
                subject = new HumanitySubject(models.Count + 1, model.Name);
            }

            models.Add(subject);
        }

        public ISubject FindById(int id) => models.FirstOrDefault(s => s.Id == id);

        public ISubject FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
    }
}
