using Homies.Data;

namespace Homies.Models
{
    public class AllEventsViewModel
    {
        public AllEventsViewModel(int id, string name, string organiser, DateTime start, string type)
        {
            Id = id;
            Name = name;
            Organiser = organiser;
            Start = start.ToString(DataConstants.DateFormat);
            Type = type;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Organiser { get; set; }

        public string Start { get; set; }

        public string Type { get; set; }
    }
}