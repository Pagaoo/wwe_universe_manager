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

        public async Task<WrestlerModel> CreateWrestler(CreateWrestlerDto wrestlerDto)
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

            return wrestler;
        }

        public async Task<WrestlerModel?> DeleteWrestler(long wrestlerId)
        {
            var wrestlerToDelete = await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestlerToDelete => wrestlerToDelete.Id == wrestlerId);
            
            if (wrestlerToDelete == null)
            {
                return null;
            }

            _appDbContext.Remove(wrestlerToDelete);
            await _appDbContext.SaveChangesAsync();
            return wrestlerToDelete;
        }

        public async Task<WrestlerModel?> EditWrestlerInfos(long id, EditWrestlerDto wrestlerDto)
        {
            var wrestlerToEdit = await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestlerToEdit => wrestlerToEdit.Id == id);

            if (wrestlerToEdit == null)
            {
                return null;
            }

            wrestlerToEdit.Name = wrestlerDto.Name;
            wrestlerToEdit.Weight = wrestlerDto.Weight;
            wrestlerToEdit.Height = wrestlerDto.Height;

            await _appDbContext.SaveChangesAsync();
            return wrestlerToEdit;
        }

        public async Task<WrestlerModel?> FindWrestlerById(long wrestlerId)
        {
            return await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestler => wrestler.Id == wrestlerId);
        }

        public async Task<List<WrestlerModel>> ListWrestlers()
        {
            var wrestlers = await _appDbContext.Wrestler.ToListAsync();
            return wrestlers;
        }
    }
}
