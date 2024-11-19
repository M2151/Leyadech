using Leyadech.Core.Entities;
using Leyadech.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leyadech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotherController : Controller
    {
        private readonly IMotherService _motherService;
        public MotherController(IMotherService motherService)
        {
            _motherService = motherService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Mother>> Get()
        {
            var result= _motherService.GetAllMothers();
            if(!result.IsSuccess)
                return StatusCode(result.StatusCode,result.ErrorMessage);
            return Ok(result.Data);
        }
        [HttpGet("{id}")]
        public ActionResult<Mother> Get(int id)
        {
            var result = _motherService.GetMotherById(id);
            if (!result.IsSuccess) return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }
        [HttpPost]
        public ActionResult<bool> Add([FromBody] Mother mother)
        {
            var result = _motherService.AddMother(mother);
            if (!result.IsSuccess) return StatusCode(result.StatusCode,result.ErrorMessage);
            return Ok(result.Data);
        }
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Mother mother)
        {
            var result = _motherService.UpdateMother(id, mother);
            if (!result.IsSuccess) return StatusCode(result.StatusCode,result.ErrorMessage);
            return Ok(result.Data);
        }
        [HttpPut("{id}/specialRequest")]
        public ActionResult<bool> UpdateSpecRequests(int id, [FromBody] string request)
        {
            var result = _motherService.AddSpecialRequest(id, request);
            if (!result.IsSuccess) return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _motherService.DeleteMother(id);
            if (!result.IsSuccess) return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Data);
        }
    }
}
