using wwe_universe_manager.Interfaces;

namespace wwe_universe_manager.Models
{
    public class WrestlerModel : IAuditable
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }

        public int Age
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
    }
}
