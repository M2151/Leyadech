﻿using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            if (result == null) return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult<bool> Add([FromBody]Volunteering volunteering)
        {
            bool result = _volunteeringService.AddVolunteering(volunteering);
            if (!result) return NotFound();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] Volunteering volunteering)
        {
            bool result=_volunteeringService.UpdateVolunteering(id, volunteering);
            if (!result) return NotFound();
            return true;
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result=_volunteeringService.DeleteVolunteering(id);
            if (!result) return NotFound();
            return true;
        }
        [HttpPut("{id}/feedback")]
        public ActionResult<bool> AddFeedback(int id,[FromBody]int satisfactionLevel,[FromBody]string feedback)
        {
            bool result = _volunteeringService.AddFeedback(id,satisfactionLevel,feedback);
            if (!result) return NotFound();
            return true;
        }

        
    }
}
