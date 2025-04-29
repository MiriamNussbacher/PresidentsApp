using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace PresidentsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentsController : ControllerBase
    {
        private readonly IPresidentService _presidentService;
        private readonly IIncriment _incriment;
        public PresidentsController(IPresidentService presidentService, IIncriment incriment)
        {

            _presidentService = presidentService;
            _incriment = incriment;
        }

        [HttpGet]
            public async Task<IActionResult> GetPresidents()
            {
                _incriment.addOne();
                var presidents = await _presidentService.GetPresidentsAsync();
                return Ok(presidents);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetPresident(int id)
            {
                var president = await _presidentService.GetPresidentByIdAsync(id);
                if (president == null)
                    return NotFound();
                return Ok(president);
            }

            [HttpPost]
            public async Task<IActionResult> AddPresident([FromBody] President president)
            {
                await _presidentService.AddPresidentAsync(president);
                return CreatedAtAction(nameof(GetPresident), new { id = president.Id }, president);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePresident(int id, [FromBody] President president)
            {
                await _presidentService.UpdatePresidentAsync( president);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePresident(int id)
            {
                await _presidentService.DeletePresidentAsync(id);
                return NoContent();
            }

            [HttpGet("born-after/{birthdate}")]
            public async Task<IActionResult> GetPresidentsBornAfter(DateTime birthdate)
            {
                var presidents = await _presidentService.GetPresidentsBornAfter(birthdate);
                return Ok(presidents);
            }
        }
    }

