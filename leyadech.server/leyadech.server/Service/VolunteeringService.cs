using leyadech.server.DTO;


namespace leyadech.server.Service
{
    public class VolunteeringService
    {

        readonly IDataContext _dataContext;

        public VolunteeringService(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _dataContext.LoadVolunteeringData();
           

        }
        public List<Volunteering> GetAllVolunteerings() => _dataContext.VolunteeringData;
        public Volunteering GetVolunteeringById(int id) 
        {
            return _dataContext.VolunteeringData.Where(vol => vol.VolunteeringId == id)
                .FirstOrDefault<Volunteering>();
        }
        public bool IsValidFields(Volunteering vol)
        {
            if (vol.DateEnd < vol.DateStart)
                return false;
            if(DateOnly.FromDateTime(DateTime.Now) > vol.DateStart)
                return false;
            if (vol.TimeEnd < vol.TimeStart)
                return false;
            return true;
        }
        public bool IsRequiredFields(Volunteering vol)
        {
            if(vol==null) return false;
            //check valid ids
            return true;
        }
        public bool AddVolunteering(Volunteering vol) 
        {
            _dataContext.LoadVolunteeringData();
            vol.VolunteeringId= _dataContext.VolunteeringData.Any()?_dataContext.VolunteeringData.Max(v=>v.VolunteeringId)+1:1;
            _dataContext.VolunteeringData.Add(vol);
            return _dataContext.SaveVolunteeringData();
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
            Volunteering original = GetVolunteeringById(id);
            SetVolunteeringFields(original, vol);
            return _dataContext.SaveVolunteeringData();
        }
        public bool DeleteVolunteering(int id) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            _dataContext.VolunteeringData.Remove(volunteering);
            return _dataContext.SaveVolunteeringData();
        }
        
        public bool AddFeedback(int id,Feedback feedback) 
        {
            Volunteering volunteering = GetVolunteeringById(id);
            volunteering.Feedback = feedback;
            return _dataContext.SaveVolunteeringData();
        }
    }
}
