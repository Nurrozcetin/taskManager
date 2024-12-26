namespace TaskManager.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public required string Frequency { get; set; }
        public bool IsCompleted = false;
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}
