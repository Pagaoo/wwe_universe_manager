using wwe_universe_manager.Dto.Wrestler;
using wwe_universe_manager.Models;

namespace wwe_universe_manager.Services.Wrestler
{
    public interface IWrestlerInterface
    {
        Task<ResponseModel<List<WrestlerModel>>> ListWrestlers();
        Task<ResponseModel<WrestlerModel>> GetWrestlerById(long wrestlerId);
        Task<ResponseModel<WrestlerModel>> CreateWrestler(CreateWrestlerDto wrestlerDto);
        Task<ResponseModel<WrestlerModel>> EditWrestlerInfos(EditWrestlerDto wrestlerDto);
        Task<ResponseModel<WrestlerModel>> DeleteWrestler(long wrestlerId);
    }
}
