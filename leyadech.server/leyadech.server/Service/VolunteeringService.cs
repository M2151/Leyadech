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
