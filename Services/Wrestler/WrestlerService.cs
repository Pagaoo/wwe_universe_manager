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
                HeightInFeet = wrestlerDto.HeightInFeet,
                HeightInInches = wrestlerDto.HeightInInches,
                WeightInPounds = wrestlerDto.WeightInPounds,
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

        public async Task<ResponseWrestlerDto?> FindWrestlerById(long wrestlerId)
        {
            var wrestler = await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestler => wrestler.Id == wrestlerId);
            
            if(wrestler == null)
            {
                return null;
            }

            var wrestlerDto = new ResponseWrestlerDto
            {
                Id = wrestler.Id,
                Name = wrestler.Name,
                Age = wrestler.Age,
                WeightInKg = wrestler.WeightInKg,
                HeightInCm = wrestler.HeightInCm,
                HeightFormatted = wrestler.HeightFormatted,
            };

            return wrestlerDto;
        }

        public async Task<WrestlerModel?> FindWrestlerModelById(long wrestlerId)
        {
            return await _appDbContext.Wrestler.FirstOrDefaultAsync(wrestler => wrestler.Id == wrestlerId);
        }

        public async Task<List<ResponseWrestlerDto>> ListWrestlers()
        {
            var wrestlers = await _appDbContext.Wrestler.Select(wrestler => new ResponseWrestlerDto
            {
                Id = wrestler.Id,
                Name = wrestler.Name,
                Age = wrestler.Age,
                WeightInKg = wrestler.WeightInKg,
                HeightInCm = wrestler.HeightInCm,
                HeightFormatted = wrestler.HeightFormatted,
            }).ToListAsync();

            return wrestlers;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
