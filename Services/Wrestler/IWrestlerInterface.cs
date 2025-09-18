using wwe_universe_manager.Models;

namespace wwe_universe_manager.Services.Wrestler
{
    public interface IWrestlerInterface
    {
        Task<ResponseModel<List<WrestlerModel>>> ListWrestlers();
        Task<ResponseModel<WrestlerModel>> GetWrestlerById(long wrestlerId);
    }
}
