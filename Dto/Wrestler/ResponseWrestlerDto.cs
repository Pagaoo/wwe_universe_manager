namespace wwe_universe_manager.Dto.Wrestler
{
    public class ResponseWrestlerDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        public double WeightInKg { get; set; }
        public double HeightInCm { get; set; }
        public required string HeightFormatted { get; set; }
    }
}
