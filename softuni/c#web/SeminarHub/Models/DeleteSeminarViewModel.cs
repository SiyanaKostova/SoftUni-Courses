namespace SeminarHub.Models
{
    public class DeleteSeminarViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = null!;
        public DateTime DateAndTime { get; set; } 
    }
}