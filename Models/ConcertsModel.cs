namespace TP3.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
