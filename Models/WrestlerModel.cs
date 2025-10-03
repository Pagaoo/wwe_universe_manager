using System.Text.Json.Serialization;
using wwe_universe_manager.Interfaces;

namespace wwe_universe_manager.Models
{
    public class WrestlerModel : IAuditable
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public int HeightInFeet { get; set; }
        [JsonIgnore]
        public int HeightInInches { get; set; }
        [JsonIgnore]
        public int WeightInPounds { get; set; }
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

        public double WeightInKg
        {
            get
            {
                const double poundsToKg = 0.45359237;
                return Math.Round(WeightInPounds * poundsToKg, 2);
            }
        }

        [JsonIgnore]
        public int TotalHeightInInches
        {
            get
            {
                return (HeightInFeet * 12) + HeightInInches;
            }
        }

        public double HeightInCm
        {
            get
            {
                const double inchesToCm = 2.54;
                return Math.Round(TotalHeightInInches * inchesToCm, 2);
            }
        }

        public string HeightFormatted
        {
            get
            {
                return $"{HeightInFeet}' {HeightInInches}";
            }
        }
    }
}
