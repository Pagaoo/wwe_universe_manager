using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("ListWreslers")]
        public async Task<ActionResult<ResponseModel<List<WrestlerModel>>>> ListWrestlers()
        {
            var wrestlers = await _wrestlerInterface.ListWrestlers();
            return Ok(wrestlers);
        }
    }
}
