namespace wwe_universe_manager.Interfaces
{
    public interface IAuditable
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set;}
    }
}
