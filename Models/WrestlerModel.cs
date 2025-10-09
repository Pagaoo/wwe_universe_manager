using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwe_universe_manager.Interfaces;

namespace wwe_universe_manager.Models
{
    public class WrestlerModel : IAuditable
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public int HeightInFeet { get; set; }
        public int HeightInInches { get; set; }
        public decimal WeightInPounds { get; set; }
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
                const decimal poundsToKg = 0.4535924m;
                return (double)Math.Round(WeightInPounds * poundsToKg, 2);
            }
        }

        [JsonIgnore]
        public int TotalHeightInInches
        {
            get
            {
                return HeightInFeet * 12 + HeightInInches;
            }
        }

        public int HeightInCm
        {
            get
            {
                const double inchesToCm = 2.54;
                double exactHeight = TotalHeightInInches * inchesToCm;
                double roundedHeight = Math.Round(exactHeight, 2);
                return (int)roundedHeight;
            }
        }

        public string HeightFormatted
        {
            get
            {
                return $"{HeightInFeet}' {HeightInInches}''";
            }
        }

        [NotMapped]
        public double? WeightInKgToPounds
        {
            set
            {
                if (value.HasValue)
                {
                    const decimal kgToPounds = 2.20462262m;
                    WeightInPounds = Math.Round((decimal)value.Value * kgToPounds, 4);
                }
            }
        }

        [NotMapped]
        public int? HeightInCmToFeetAndInch
        {
            set
            {
                if (value.HasValue)
                {
                    const double cmToInch = 0.3937008;
                    double totalInches = value.Value * cmToInch;

                    HeightInFeet = (int)totalInches/12;
                    HeightInInches = (int)Math.Round(totalInches % 12);
                }
            }
        }

    }
}
