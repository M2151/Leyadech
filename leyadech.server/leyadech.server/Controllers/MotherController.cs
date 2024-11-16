using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotherController : Controller
    {
        readonly MotherService _motherService;
        public MotherController(MotherService motherService)
        {
            _motherService = motherService;
        }
        [HttpGet]
        public ActionResult<List<Mother>> Get()
        {
            return _motherService.GetAllMothers();
        }
        [HttpGet("{id}")]
        public ActionResult<Mother> Get(int id)
        {
            Mother mother=_motherService.GetMotherById(id);
            if(mother == null) return NotFound();
            return Ok(mother);
        }
        [HttpPost]
        public ActionResult<bool>Add([FromBody]Mother mother)
        {
            if(!_motherService.IsRequiredFields(mother)) return BadRequest();
            if (!_motherService.IsValidFields(mother)) return BadRequest();
            bool result= _motherService.AddMother(mother);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<bool>Update(int id, [FromBody] Mother mother)
        {
            if(!_motherService.IsValidFields(mother)) return BadRequest();
            if(_motherService.GetMotherById(id)==null) return NotFound();
            bool result= _motherService.UpdateMotherFields(id, mother);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id}/specialRequest")]
        public ActionResult<bool>UpdateSpecRequests(int id, [FromBody] string request)
        {
            if (_motherService.GetMotherById(id) == null) return NotFound();
            bool result=_motherService.AddSpecialRequest(id,request);
            if (!result) return BadRequest();
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_motherService.GetMotherById(id) == null) return NotFound();
            bool result=_motherService.DeleteMother(id);
            if (!result) return  BadRequest();
            return true;
        }

    }
}
