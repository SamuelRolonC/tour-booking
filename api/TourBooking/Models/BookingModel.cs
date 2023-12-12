using Core.Entity;

namespace TourBooking.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public int TourId { get; set; }
        public string TourName { get; set; } = string.Empty;
    }
}
