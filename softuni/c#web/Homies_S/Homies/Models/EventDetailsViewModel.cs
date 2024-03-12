using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.CodeAnalysis.Scripting;
using static System.Collections.Specialized.BitVector32;
using System.Text;
using System;

namespace Homies.Models
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Organiser { get; set; }
        public string CreatedOn { get; set; }
        public string Type { get; set; }
    }
}