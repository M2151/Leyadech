using leyadech.server.DTO;


namespace leyadech.server.Service
{
    public class VolunteeringService
    {

       
        public List<Volunteering> GetAllVolunteerings() => DataContextManage.Lists.AllVolunteerings;
        public Volunteering GetVolunteeringById(int id) 
        {
            return DataContextManage.Lists.AllVolunteerings.Where(vol => vol.VolunteeringId == id)
                .FirstOrDefault<Volunteering>();
        }
        public bool IsValidFields(Volunteering vol)
        {
            if(vol==null) return false;
            SuggestService suggestService = new SuggestService();
            RequestService requestService = new RequestService();
            if (suggestService.GetSuggestById(vol.SuggestId) == null)
                return false;
            if (requestService.GetRequestById(vol.RequestId) == null)
                return false;
            if (vol.DateEnd < vol.DateStart)
                return false;
            if (vol.TimeEnd < vol.TimeStart)
                return false;
            return true;
        }
        public bool AddVolunteering(Volunteering vol) 
        {
            if(!IsValidFields(vol)) return false;
            vol.VolunteeringId= DataContextManage.Lists.AllVolunteerings.Max(v=>v.VolunteeringId)+1;
            return true;
        }
        public void SetVolunteeringFields(Volunteering orig,Volunteering newVo)
        {
            orig.Feedback= newVo.Feedback;
            orig.HelpFrequency= newVo.HelpFrequency;
            orig.TimeEnd= newVo.TimeEnd;
            orig.TimeStart= newVo.TimeStart;
            orig.DateStart= newVo.DateStart;
            orig.DateEnd= newVo.DateEnd;
            orig.Description= newVo.Description;
            orig.HelpKind= newVo.HelpKind;
            orig.RequestId= newVo.RequestId;
            orig.SuggestId= newVo.SuggestId;
        }
        public bool UpdateVolunteering(int id, Volunteering vol) 
        {
            if (!IsValidFields(vol)) return false;
            Volunteering original = GetVolunteeringById(id);
            if(original == default(Volunteering))
                return false;
            SetVolunteeringFields(original, vol);
            return true;
        }
        public bool DeleteVolunteering(int id) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            if (volunteering == default(Volunteering))
                return false;
            DataContextManage.Lists.AllVolunteerings.Remove(volunteering);
            return true;
        }
        
        public bool AddFeedback(int id,Feedback feedback) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            if (volunteering == default(Volunteering))
                return false;
            volunteering.Feedback = feedback;
            return true;
        }
    }
}
