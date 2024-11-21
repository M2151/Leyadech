using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteeringController : ControllerBase
    {
        private readonly IVolunteeringService _volunteeringService;

        public VolunteeringController(IVolunteeringService volunteeringService)
        {
            _volunteeringService = volunteeringService;
        }

        /// <summary>
        /// Gets a list of all volunteerings.
        /// </summary>
        /// <returns>A list of volunteerings.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Volunteering>> GetAll()
        {
            var result = _volunteeringService.GetAllVolunteerings();
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Gets a specific volunteering by ID.
        /// </summary>
        /// <param name="id">The ID of the volunteering.</param>
        /// <returns>Volunteering details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Volunteering> GetById(int id)
        {
            var result = _volunteeringService.GetVolunteeringById(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Adds a new volunteering record.
        /// </summary>
        /// <param name="volunteering">The volunteering details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Volunteering volunteering)
        {
            var result = _volunteeringService.AddVolunteering(volunteering);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Updates an existing volunteering record by ID.
        /// </summary>
        /// <param name="id">The ID of the volunteering.</param>
        /// <param name="volunteering">The updated volunteering details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Volunteering volunteering)
        {
            var result = _volunteeringService.UpdateVolunteering(id, volunteering);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Deletes a volunteering record by its ID.
        /// </summary>
        /// <param name="id">The ID of the volunteering.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _volunteeringService.DeleteVolunteering(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }
    }
}
