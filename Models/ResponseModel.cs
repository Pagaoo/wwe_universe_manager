namespace wwe_universe_manager.Models
{
    public class ResponseModel<T>
    {
        //Data pode ser nulo se não haver nada no banco => T?
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
