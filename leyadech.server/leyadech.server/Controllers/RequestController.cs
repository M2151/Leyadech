using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private readonly RequestService _requestService;
        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public ActionResult<List<HelpRequest>> Get(int? motherId)
        {
            List<HelpRequest> requests;
            if (motherId.HasValue)
            {
                if (!_requestService.IsMotherExist(motherId.Value))
                    return NotFound();
                requests = _requestService.GetReqByMotherId(motherId.Value);
            }
            else
                requests = _requestService.GetAllRequests();
            return Ok(requests);

        }

        [HttpGet("relevant")]
        public ActionResult<List<HelpRequest>> GetRelevant()
        {
            var relevantRequests = _requestService.GetAllRelevantRequests();
            return Ok(relevantRequests);
        }

        [HttpGet("{id}")]
        public ActionResult<HelpRequest> Get(int id)
        {
            var request = _requestService.GetRequestById(id);
            if (request == null)
                return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public ActionResult<bool> Add([FromBody] HelpRequest request)
        {
            if (!_requestService.IsValidFields(request)) return BadRequest();
            bool result = _requestService.AddRequest(request);
            if (!result)
                return BadRequest("Invalid request details.");
            return true;
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] HelpRequest request)
        {
            if (!_requestService.IsValidFields(request)) return BadRequest();
            bool result = _requestService.UpdateRequest(id, request);
            if (!result)
                return NotFound();
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result = _requestService.DeleteRequest(id);
            if (!result)
                return NotFound();

            return true;
        }

        
    }
}
