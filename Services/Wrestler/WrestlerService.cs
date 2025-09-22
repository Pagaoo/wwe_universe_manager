using Microsoft.EntityFrameworkCore;
using wwe_universe_manager.Data;
using wwe_universe_manager.Dto.Wrestler;
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

        public async Task<ResponseModel<WrestlerModel>> CreateWrestler(WrestlerDto wrestlerDto)
        {
            ResponseModel<WrestlerModel> response = new ResponseModel<WrestlerModel>();

            try
            {
                var wrestler = new WrestlerModel()
                {
                    Name = wrestlerDto.Name,
                    Height = wrestlerDto.Height,
                    Weight = wrestlerDto.Weight,
                    BirthDate = wrestlerDto.BirthDate
                };

                _appDbContext.Add(wrestler);
                await _appDbContext.SaveChangesAsync();

                response.Data = wrestler;
                response.Message = "Wrestler successfully created";
                response.Status = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<WrestlerModel>> GetWrestlerById(long wrestlerId)
        {
            ResponseModel<WrestlerModel> response = new ResponseModel<WrestlerModel>();
            
            try
            {
                var wrestler = await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestler => wrestler.Id == wrestlerId);
                if (wrestler == null)
                {
                    response.Message = "Wrestler not found";
                    return response;
                }
                response.Data = wrestler;
                response.Message = "Wrestler found";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
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
