using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuggestController : ControllerBase
    {
        private readonly ISuggestService _suggestService;

        public SuggestController(ISuggestService suggestService)
        {
            _suggestService = suggestService;
        }

        /// <summary>
        /// Gets a list of all suggestions.
        /// </summary>
        /// <returns>A list of suggestions.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Suggest>> GetAll()
        {
            var result = _suggestService.GetAllSuggests();
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Gets a specific suggestion by ID.
        /// </summary>
        /// <param name="id">The ID of the suggestion.</param>
        /// <returns>Suggestion details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Suggest> GetById(int id)
        {
            var result = _suggestService.GetSuggestById(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Adds a new suggestion.
        /// </summary>
        /// <param name="suggest">The suggestion details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Suggest suggest)
        {
            var result = _suggestService.AddSuggest(suggest);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Updates an existing suggestion by ID.
        /// </summary>
        /// <param name="id">The ID of the suggestion.</param>
        /// <param name="suggest">The updated suggestion details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Suggest suggest)
        {
            var result = _suggestService.UpdateSuggest(id, suggest);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Deletes a suggestion by its ID.
        /// </summary>
        /// <param name="id">The ID of the suggestion.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _suggestService.DeleteSuggest(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }
    }
}
