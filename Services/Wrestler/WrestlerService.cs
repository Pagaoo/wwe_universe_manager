using Microsoft.EntityFrameworkCore;
using wwe_universe_manager.Data;
using wwe_universe_manager.Models;

namespace wwe_universe_manager.Services.Wrestler
{
    public class WrestlerService : IWrestlerInterface
    {
        private readonly AppDbContext _appDbContext;
        public WrestlerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<ResponseModel<WrestlerModel>> GetWrestlerById(long wrestlerId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<WrestlerModel>>> ListWrestlers()
        {
            ResponseModel<List<WrestlerModel>> response = new ResponseModel<List<WrestlerModel>>();
            
            try
            {
                var wrestlers = await _appDbContext.Wrestler.ToListAsync();
                response.Data = wrestlers;
                response.Message = "All wrestlers were listed";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
