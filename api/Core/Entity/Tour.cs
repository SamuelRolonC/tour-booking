namespace Core.Entity
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}