namespace TourBooking.Models
{
    public class ListResultModel<T> : ResultModel where T : class
    {
        public List<T> Data { get; set; } = new List<T>();
    }
}
