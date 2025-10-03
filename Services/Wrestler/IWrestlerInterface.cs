using wwe_universe_manager.Dto.Wrestler;
using wwe_universe_manager.Models;

namespace wwe_universe_manager.Services.Wrestler
{
    public interface IWrestlerInterface
    {
        Task<List<ResponseWrestlerDto>> ListWrestlers();
        Task<ResponseWrestlerDto?> FindWrestlerById(long wrestlerId);
        Task<WrestlerModel?> FindWrestlerModelById(long wrestlerId);
        Task<WrestlerModel> CreateWrestler(CreateWrestlerDto wrestlerDto);
        Task<WrestlerModel?> DeleteWrestler(long wrestlerId);
        Task<int> SaveChangesAsync();
    }
}
