namespace TourBooking.Models
{
    public class TourModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Destination { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public decimal? Price { get; set; }
    }
}
