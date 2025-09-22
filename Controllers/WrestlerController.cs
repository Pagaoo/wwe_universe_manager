using Microsoft.AspNetCore.Mvc;
using wwe_universe_manager.Dto.Wrestler;
using wwe_universe_manager.Models;
using wwe_universe_manager.Services.Wrestler;

namespace wwe_universe_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WrestlerController : ControllerBase
    {
        private readonly IWrestlerInterface _wrestlerInterface;
        public WrestlerController(IWrestlerInterface wrestlerInterface)
        {
            _wrestlerInterface = wrestlerInterface;
        }

        //TODO: Futuramente refatorar as rotas para seguir o padrão REST

        [HttpGet("ListWreslers")]
        public async Task<ActionResult<ResponseModel<List<WrestlerModel>>>> ListWrestlers()
        {
            var wrestlers = await _wrestlerInterface.ListWrestlers();
            return Ok(wrestlers);
        }

        [HttpGet("GetWrestlerById/{wrestlerId}")]
        public async Task<ActionResult<WrestlerModel>> GetWrestlerById(long wrestlerId)
        {
            var wrestler = await _wrestlerInterface.GetWrestlerById(wrestlerId);
            return Ok(wrestler);
        }

        [HttpPost("CreateWrestler")]
        public async Task<ActionResult<WrestlerModel>> CreateWrestler(CreateWrestlerDto wrestlerDto)
        {
            var wrestler = await _wrestlerInterface.CreateWrestler(wrestlerDto);
            return Ok(wrestler);
        }

        [HttpDelete("DeleteWrestler/{wrestlerId}")]
        public async Task<ActionResult<WrestlerModel>> DeleteWrestler(long wrestlerId)
        {
            var wrestlerToDelete = await _wrestlerInterface.DeleteWrestler(wrestlerId);

            if (!wrestlerToDelete.Status)
            {
                return NotFound(wrestlerToDelete);
            }

            return Ok(wrestlerToDelete);
        }
    }
}
