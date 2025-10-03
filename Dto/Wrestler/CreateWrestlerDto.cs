namespace wwe_universe_manager.Dto.Wrestler
{
    public class CreateWrestlerDto
    {
        public required string Name { get; set; }
        public int HeightInFeet { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInPounds { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
