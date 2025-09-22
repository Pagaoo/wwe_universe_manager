namespace wwe_universe_manager.Dto.Wrestler
{
    public class CreateWrestlerDto
    {
        public required string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
