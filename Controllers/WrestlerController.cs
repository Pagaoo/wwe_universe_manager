using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet()]
        public async Task<ActionResult<ResponseModel<List<WrestlerModel>>>> ListWrestlers()
        {
            var wrestlers = await _wrestlerInterface.ListWrestlers();
            return Ok(wrestlers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WrestlerModel>> GetWrestlerById(long id)
        {
            var wrestler = await _wrestlerInterface.FindWrestlerById(id);
            if (wrestler == null)
            {
                return NotFound(new { message = "Wrestler not found!" });
            }

            return Ok(wrestler);
        }

        [HttpPost()]
        public async Task<ActionResult<WrestlerModel>> CreateWrestler(CreateWrestlerDto wrestlerDto)
        {
            var wrestler = await _wrestlerInterface.CreateWrestler(wrestlerDto);
            return CreatedAtAction(nameof(GetWrestlerById), new { id = wrestler.Id }, wrestler);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WrestlerModel>> DeleteWrestler(long id)
        {
            var wrestlerToDelete = await _wrestlerInterface.DeleteWrestler(id);

            if (wrestlerToDelete == null)
            {
                return NotFound();
            }

            return Ok(wrestlerToDelete);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<WrestlerModel>> UpdateWrestler(long id, [FromBody] JsonPatchDocument<WrestlerModel> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("Patch document cannot be null");
            }

            var wrestlerToEdit = await _wrestlerInterface.FindWrestlerById(id);

            if(wrestlerToEdit == null)
            {
                return NotFound("Wrestler not found");
            }

            patchDocument.ApplyTo(wrestlerToEdit, error =>
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _wrestlerInterface.SaveChangesAsync();

            return Ok(wrestlerToEdit);
        }
    }
}
