using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class VolunteerService
    {
        
        public List<Volunteer> GetAllVolunteers()
        {
            return DataContextManage.Lists.AllVolunteers;
        }
        public Volunteer GetVolunteerById(int id)
        {
            return DataContextManage.Lists.AllVolunteers.Where(v => v.Id == id).FirstOrDefault<Volunteer>();
        }
        public bool AddVolunteer(Volunteer volunteer)
        {
            volunteer.Id = DataContextManage.Lists.AllVolunteers.Max(v => v.Id) + 1;
            DataContextManage.Lists.AllVolunteers.Add(volunteer); return true;
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
            SuggestService suggestService = new SuggestService();
            return volunteeringService.GetAllVolunteerings()
                .Where(vol=> suggestService.GetSuggestById(vol.SuggestId).UserId==id)
                .ToList();
        }
    }
}
