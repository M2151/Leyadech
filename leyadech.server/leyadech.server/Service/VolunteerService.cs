using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class VolunteerService
    {
        List<Volunteer> _allVolunteers;
        public VolunteerService()
        {
            _allVolunteers= new List<Volunteer>();
        }
        public List<Volunteer> GetAllVolunteers()
        {
            return _allVolunteers;
        }
        public Volunteer GetVolunteerById(int id)
        {
            return _allVolunteers.Where(v => v.Id == id).FirstOrDefault<Volunteer>();
        }
        public bool AddVolunteer(Volunteer volunteer)
        {
            volunteer.Id = _allVolunteers.Max(v => v.Id) + 1;
            _allVolunteers.Add(volunteer); return true;
        }
        public void SetVolunteerFields(Volunteer originalVol, Volunteer newVol)
        {

        }
        public bool UpdateVolunteerFields(int id, Volunteer volunteer)
        {
            Volunteer original = GetVolunteerById(id);
            if (original == default(Volunteer))
                return false;
            SetVolunteerFields(original, volunteer);
            return true;
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
            Volunteer volunteer = GetVolunteerById(id);
            if (volunteer == default(Volunteer))
                return false;
            volunteer.Status = status;
            return true;
        }
        public List<Volunteering> GetAllVolunteeringsById(int id)
        {
            VolunteeringService volunteeringService = new VolunteeringService();
            return volunteeringService.GetAllVolunteerings()
                .Where(vol=>vol.VolunteerId==id).ToList();
        }
    }
}
