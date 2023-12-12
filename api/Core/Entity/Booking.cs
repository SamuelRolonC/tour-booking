namespace Core.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TourId { get; set; }
        public Tour? Tour { get; set; }
    }
}