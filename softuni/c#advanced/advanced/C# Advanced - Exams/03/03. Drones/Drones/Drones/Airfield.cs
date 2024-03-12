using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip  { get; set; }
        public List<Drone> Drones { get; set; }
        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }
            else if(drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }
            else if(Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Name == name)
                {
                    Drones.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int countOfRemovedDrones = 0;

            while ((Drones.FirstOrDefault(d => d.Brand == brand)) != null)
            {
                var targetDrone = Drones.FirstOrDefault(d => d.Brand == brand);
                Drones.Remove(targetDrone);
                countOfRemovedDrones++;
            }

            return countOfRemovedDrones;
        }
        public Drone FlyDrone(string name)
        {
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Name == name)
                {
                    Drones[i].Available = false;
                    return Drones[i];
                }
            }

            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> list = new List<Drone>();

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Range >= range)
                {
                    list.Add(Drones[i]);
                    Drones[i].Available = false;
                }
            }

            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
