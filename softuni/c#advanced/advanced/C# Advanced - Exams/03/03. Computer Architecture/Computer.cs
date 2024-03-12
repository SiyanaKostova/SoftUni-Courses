using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            for (int i = 0; i < Multiprocessor.Count; i++)
            {
                if (Multiprocessor[i].Brand == brand)
                {
                    Multiprocessor.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public CPU MostPowerful()
        {
            if (Multiprocessor.Count == 0)
            {
                return null;
            }

            CPU mostPowerful = Multiprocessor[0];

            foreach (var cpu in Multiprocessor)
            {
                if (cpu.Frequency > mostPowerful.Frequency)
                {
                    mostPowerful = cpu;
                }
            }

            return mostPowerful;
        }
        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(c => c.Brand == brand);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine($"{cpu.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
