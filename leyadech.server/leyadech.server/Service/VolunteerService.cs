using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class VolunteerHelper
    {
        readonly IDataContext _dataContext;
        public VolunteerHelper(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _dataContext.LoadVolunteerData();
           
        }
        public Volunteer GetVolunteerById(int id)
        {
            return _dataContext.VolunteerData.Where(v => v.Id == id).FirstOrDefault<Volunteer>();
        }
    }
    public class VolunteerService:UserService
    {
        readonly IDataContext _dataContext;
        public readonly VolunteerHelper _volunteerHelper;
        readonly SuggestService _suggestService;
        readonly VolunteeringService _volunteeringService;
        public VolunteerService(IDataContext dataContext,VolunteerHelper volunteerHelper,VolunteeringService volunteeringService,SuggestService suggestService)
        {
            _dataContext = dataContext;
            _dataContext.LoadVolunteerData();
            _suggestService = suggestService;
            _volunteeringService = volunteeringService;
            _volunteerHelper = volunteerHelper;
        }
        public List<Volunteer> GetAllVolunteers()
        {
            return _dataContext.VolunteerData;
        }
       
        public bool AddVolunteer(Volunteer volunteer)
        {
            volunteer.Id = _dataContext.VolunteerData.Any()? _dataContext.VolunteerData.Max(v => v.Id) + 1:1;
            volunteer.JoinDate=DateOnly.FromDateTime(DateTime.Now);
            _dataContext.VolunteerData.Add(volunteer);
            return _dataContext.SaveVolunteerData();
        }
        public void SetVolunteerFields(Volunteer originalVol, Volunteer newVol)
        {
            originalVol.Email = newVol.Email;
            originalVol.FirstName = newVol.FirstName;
            originalVol.LastName = newVol.LastName;
            originalVol.PhoneNumber= newVol.PhoneNumber;
            originalVol.Address= newVol.Address;
            originalVol.HelpKindSuggested = newVol.HelpKindSuggested;
            originalVol.Status = newVol.Status;
            
        }
        public bool IsRequiredFields(Volunteer volunteer)
        {
            if(volunteer == null) return false;
            if(volunteer.Email == null) return false;
            return true;
        }
        public bool IsValidFields(Volunteer volunteer)
        {
            if(volunteer == null) return false;
            if(!IsvalidEmail(volunteer.Email))return false;
            if(!IsValidPhone(volunteer.PhoneNumber))return false;
            return true;
        }
        public bool UpdateVolunteerFields(int id, Volunteer volunteer)
        {
            Volunteer original = _volunteerHelper.GetVolunteerById(id);
            SetVolunteerFields(original, volunteer);
            return _dataContext.SaveVolunteerData();
        }
        //public bool DeleteVolunteer(int id)
        //{
        //    Volunteer volunteer = GetVolunteerById(id);
        //    if (volunteer == default(Volunteer)) return false;
        //    _allMothers.Remove(volunteer);
        //    return true;
        //
        public bool UpdateVolunteerStatus(int id, EVolunteerStatus status)
        {
            Volunteer volunteer = _volunteerHelper.GetVolunteerById(id);
            volunteer.Status = status;
            return _dataContext.SaveVolunteerData();
        }
        public List<Volunteering> GetAllVolunteeringsById(int id)
        {
            return _volunteeringService.GetAllVolunteerings()
                .Where(vol=> _suggestService.GetSuggestById(vol.SuggestId).UserId==id)
                .ToList();
        }
    }
}
