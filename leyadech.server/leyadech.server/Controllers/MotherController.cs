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
        readonly MotherService _motherService=new MotherService();
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
            if (!_motherService.IsValidFields(mother)) return BadRequest();
            bool result =_motherService.AddMother(mother);
            if (!result) return BadRequest();
            return result;
        }
        [HttpPut("{id}")]
        public ActionResult<bool>Update(int id, [FromBody] Mother mother)
        {
            if(!_motherService.IsValidFields(mother)) return BadRequest();
            bool result=_motherService.UpdateMotherFields(id, mother);
            if (!result) return NotFound();
            return true;
        }
        [HttpPut("{id}/specialRequest")]
        public ActionResult<bool>UpdateSpecRequests(int id, [FromBody] string request)
        {
            bool result=_motherService.AddSpecialRequest(id,request);
            if (!result) return NotFound();
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result=_motherService.DeleteMother(id);
            if (!result) return NotFound();
            return true;
        }

    }
}
