using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leyadech.server.Controllers
{
    [Controller]
    [Route("volunteerings")]
    public class VolunteeringController : Controller
    {
        readonly VolunteeringService _volunteeringService;
        public VolunteeringController()
        {
            _volunteeringService = new VolunteeringService();
        }
        [HttpGet]
        public ActionResult<List<Volunteering>> Get()
        {
            return _volunteeringService.GetAllVolunteerings();
        }
        [HttpGet("{id}")]
        public ActionResult<Volunteering> Get(int id)
        {
            Volunteering result = _volunteeringService.GetVolunteeringById(id);
            if (result == null) return Unauthorized();
            return result;
        }
        [HttpPost]
        public ActionResult Add([FromBody]Volunteering volunteering)
        {
            bool result = _volunteeringService.AddVolunteering(volunteering);
            if (!result) return Unauthorized();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Volunteering volunteering)
        {
            bool result=_volunteeringService.UpdateVolunteering(id, volunteering);
            if (!result) return Unauthorized();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool result=_volunteeringService.DeleteVolunteering(id);
            if (!result) return Unauthorized();
            return Ok();
        }
        [HttpPut("{id}/feedback")]
        public ActionResult AddFeedback(int id,[FromBody]int satisfactionLevel,[FromBody]string feedback)
        {
            bool result = _volunteeringService.AddFeedback(id,satisfactionLevel,feedback);
            if (!result) return Unauthorized();
            return Ok();
        }

        
    }
}
