using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class VolunteeringService
    {
        public list<Volunteering> GetAllVolunteerings() { }
        public Volunteering GetVolunteeringById(int id) { }
        public bool UpdateVolunteering(int id, Volunteering request) { }
        public bool DeleteVolunteering(int id) { }
        public bool AddVolunteering(Volunteering request) { }
        public bool AddFeedback(int satisfactionLevel,string feedback)
    }
}
