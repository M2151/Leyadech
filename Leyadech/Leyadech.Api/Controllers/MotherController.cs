using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    /// <summary>
    /// Controller to manage Mother entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MotherController : Controller
    {
        private readonly IMotherService _motherService;

        public MotherController(IMotherService motherService)
        {
            _motherService = motherService;
        }

        /// <summary>
        /// Gets a list of all mothers.
        /// </summary>
        /// <returns>List of mothers.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Mother>> Get()
        {
            var result = _motherService.GetAllMothers();
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Data);
        }

        /// <summary>
        /// Gets a specific mother by ID.
        /// </summary>
        /// <param name="id">The ID of the mother.</param>
        /// <returns>Mother details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Mother> Get(int id)
        {
            var result = _motherService.GetMotherById(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Data);
        }

        /// <summary>
        /// Adds a new mother.
        /// </summary>
        /// <param name="mother">Mother details.</param>
        /// <returns>Success status.</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Mother mother)
        {
            if (mother == null)
                return BadRequest("Mother data is required.");

            var result = _motherService.AddMother(mother);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return CreatedAtAction(nameof(Get), new { id = mother.Id }, result.Data);
        }

        /// <summary>
        /// Updates an existing mother.
        /// </summary>
        /// <param name="id">The ID of the mother to update.</param>
        /// <param name="mother">Updated mother details.</param>
        /// <returns>Success status.</returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Mother mother)
        {
            if (mother == null)
                return BadRequest("Mother data is required.");

            var result = _motherService.UpdateMother(id, mother);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return NoContent();
        }

        /// <summary>
        /// Updates the special request for a specific mother.
        /// </summary>
        /// <param name="id">The ID of the mother.</param>
        /// <param name="request">The special request.</param>
        /// <returns>Success status.</returns>
        [HttpPut("{id}/specialRequest")]
        public ActionResult<bool> UpdateSpecRequests(int id, [FromBody] string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                return BadRequest("Special request data is required.");

            var result = _motherService.AddSpecialRequest(id, request);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return NoContent();
        }

        /// <summary>
        /// Deletes a mother by ID.
        /// </summary>
        /// <param name="id">The ID of the mother to delete.</param>
        /// <returns>Success status.</returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _motherService.DeleteMother(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return NoContent();
        }
    }
}
