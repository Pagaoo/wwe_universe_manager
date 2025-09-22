namespace wwe_universe_manager.Dto.Wrestler
{
    public class EditWrestlerDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
