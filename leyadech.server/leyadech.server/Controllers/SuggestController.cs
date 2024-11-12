using leyadech.server.DTO;
using leyadech.server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace leyadech.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuggestController : Controller
    {
        private readonly SuggestService _suggestService = new SuggestService();

        [HttpGet]
        public ActionResult<List<HelpSuggest>> Get(int? volId)
        {
            List<HelpSuggest> suggests;
            if (volId.HasValue)
            {
                VolunteerService volService = new VolunteerService();
                if (volService.GetVolunteerById(volId.Value) == null)
                    return BadRequest();
                suggests = _suggestService.GetSegByVolId(volId.Value);
            }
            else
                 suggests = _suggestService.GetAllSuggests();
            return Ok(suggests);
        }

        [HttpGet("relevant")]
        public ActionResult<List<HelpSuggest>> GetRelevant()
        {
            var relevantSuggests = _suggestService.GetAllRelevantSuggests();
            return Ok(relevantSuggests);
        }

        [HttpGet("{id}")]
        public ActionResult<HelpSuggest> Get(int id)
        {
            var suggest = _suggestService.GetSuggestById(id);
            if (suggest == null)
                return NotFound();
            return Ok(suggest);
        }

        [HttpPost]
        public ActionResult<bool> Add([FromBody] HelpSuggest suggest)
        {
            if (!_suggestService.IsValidFields(suggest)) return false;
            bool result = _suggestService.AddSuggest(suggest);
            if (!result)
                return BadRequest();
            return true;
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody] HelpSuggest suggest)
        {
            if (!_suggestService.IsValidFields(suggest)) return false;
            bool result = _suggestService.UpdateSuggest(id, suggest);
            if (!result)
                return NotFound();
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result = _suggestService.DeleteSuggest(id);
            if (!result)
                return NotFound();
            return true;
        }

        
    }
}
