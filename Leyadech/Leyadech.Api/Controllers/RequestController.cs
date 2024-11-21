using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Gets a list of all requests.
        /// </summary>
        /// <returns>A list of requests.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetAll()
        {
            var result = _requestService.GetAllRequests();
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Gets a specific request by ID.
        /// </summary>
        /// <param name="id">The ID of the request.</param>
        /// <returns>Request details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Request> GetById(int id)
        {
            var result = _requestService.GetRequestById(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Adds a new request.
        /// </summary>
        /// <param name="request">The request details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Request request)
        {
            var result = _requestService.AddRequest(request);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Updates an existing request by ID.
        /// </summary>
        /// <param name="id">The ID of the request.</param>
        /// <param name="request">The updated request details.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Request request)
        {
            var result = _requestService.UpdateRequest(id, request);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        /// <summary>
        /// Deletes a request by its ID.
        /// </summary>
        /// <param name="id">The ID of the request.</param>
        /// <returns>A result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _requestService.DeleteRequest(id);
            if (!result.IsSuccess)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }
    }
}
