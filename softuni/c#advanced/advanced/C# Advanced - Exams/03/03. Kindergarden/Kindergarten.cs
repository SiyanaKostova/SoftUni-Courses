using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry  { get; set; }
        public int ChildrenCount { get { return Registry.Count; } }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveChild(string childFullName)
        {
            string[] fullName = childFullName.Split();

            string firstName = fullName[0];
            string lastName = fullName[1];

            for (int i = 0; i < Registry.Count; i++)
            {
                if (Registry[i].FirstName == firstName && Registry[i].LastName == lastName)
                {
                    Registry.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string[] fullName = childFullName.Split();

            string firstName = fullName[0];
            string lastName = fullName[1];

            for (int i = 0; i < Registry.Count; i++)
            {
                if (Registry[i].FirstName == firstName && Registry[i].LastName == lastName)
                {
                    return Registry[i];
                }
            }
            return null;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");

            var sortedRegistry = Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x=>x.FirstName);

            foreach (var item in sortedRegistry)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
