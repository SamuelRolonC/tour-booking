using Core.Entity;

namespace Test.Data
{
    public class TourData
    {
        public static List<Tour> GetTourListValid()
        {
            return new List<Tour>
            {
                new Tour
                {
                    Id = 1,
                    Name = "Tour 1",
                    Destination = "Destination 1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    Price = 100.5M
                },
                new Tour
                {
                    Id = 2,
                    Name = "Tour 2",
                    Destination = "Destination 2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    Price = 200.1M
                }
            };
        }
    }
}
