using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteeringController : Controller
    {
        readonly VolunteeringService _volunteeringService;
        public VolunteeringController(VolunteeringService volunteeringService)
        {
            _volunteeringService = volunteeringService;
        }
        [HttpGet]
        public ActionResult<List<Volunteering>> Get()
        {
            return Ok(_volunteeringService.GetAllVolunteerings());
        }
        [HttpGet("{id}")]
        public ActionResult<Volunteering> Get(int id)
        {
            Volunteering result = _volunteeringService.GetVolunteeringById(id);
            if (result == null) return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult<bool> Add([FromBody]Volunteering volunteering)
        {
            if(!_volunteeringService.IsRequiredFields(volunteering)) 
                return BadRequest();
            if(!_volunteeringService.IsValidFields(volunteering))
                return BadRequest();
            bool result = _volunteeringService.AddVolunteering(volunteering);
            if (!result) return BadRequest();
            return true;
        }
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Volunteering volunteering)
        {
            if(_volunteeringService.GetVolunteeringById(id)==null)
                return NotFound();
            if(!_volunteeringService.IsValidFields(volunteering)) return BadRequest();
            bool result=_volunteeringService.UpdateVolunteering(id, volunteering);
            if (!result) return NotFound();
            return true;
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_volunteeringService.GetVolunteeringById(id) == null)
                return NotFound();
            bool result=_volunteeringService.DeleteVolunteering(id);
            if (!result) return BadRequest();
            return true;
        }
        [HttpPut("{id}/feedback")]
        public ActionResult<bool> AddFeedback(int id,[FromBody]Feedback feedback)
        {
            if (_volunteeringService.GetVolunteeringById(id) == null)
                return NotFound();
            if (feedback == null) return BadRequest();
            bool result = _volunteeringService.AddFeedback(id,feedback);
            if (!result) return BadRequest();
            return true;
        }

        
    }
}
