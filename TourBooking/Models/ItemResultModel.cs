namespace TourBooking.Models
{
    public class ItemResultModel<T> : ResultModel where T : class
    {
        public T? Data { get; set; }
    }
}
