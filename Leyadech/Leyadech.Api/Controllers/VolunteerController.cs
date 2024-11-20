using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Leyadech.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    /// <summary>
    /// Controller to manage Volunteer entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        /// <summary>
        /// Gets a list of all volunteers.
        /// </summary>
        /// <returns>List of volunteers.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Volunteer>> Get()
        {
            var result = _volunteerService.GetAllVolunteers();
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Data);
        }

        /// <summary>
        /// Gets a specific volunteer by ID.
        /// </summary>
        /// <param name="id">The ID of the volunteer.</param>
        /// <returns>Volunteer details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Volunteer> Get(int id)
        {
            var result = _volunteerService.GetVolunteerById(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Data);
        }

        /// <summary>
        /// Adds a new volunteer.
        /// </summary>
        /// <param name="volunteer">Volunteer details.</param>
        /// <returns>Success status.</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Volunteer volunteer)
        {
            if (volunteer == null)
                return BadRequest("Volunteer data is required.");

            var result = _volunteerService.AddVolunteer(volunteer);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return CreatedAtAction(nameof(Get), new { id = volunteer.Id }, result.Data);
        }

        /// <summary>
        /// Updates an existing volunteer.
        /// </summary>
        /// <param name="id">The ID of the volunteer to update.</param>
        /// <param name="volunteer">Updated volunteer details.</param>
        /// <returns>Success status.</returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Volunteer volunteer)
        {
            if (volunteer == null)
                return BadRequest("Volunteer data is required.");

            var result = _volunteerService.UpdateVolunteer(id, volunteer);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return NoContent();
        }

        /// <summary>
        /// Deletes a volunteer by ID.
        /// </summary>
        /// <param name="id">The ID of the volunteer to delete.</param>
        /// <returns>Success status.</returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _volunteerService.DeleteVolunteer(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return NoContent();
        }
    }
}
