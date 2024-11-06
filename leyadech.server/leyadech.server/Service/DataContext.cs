using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class DataContext
    {
        public List<Mother> AllMothers { get; set; }
        public List<Volunteer> AllVolunteers { get; set; }
        public List<HelpRequest> AllRequests { get; set; }
        public List<HelpSuggest> AllSuggests { get; set; }
        public List<Volunteering> AllVolunteerings { get; set; }
        
        public DataContext()
        {
            AllMothers = new List<Mother>();
            AllVolunteers= new List<Volunteer>();
            AllRequests = new List<HelpRequest>();
            AllSuggests = new List<HelpSuggest>();
            AllVolunteerings = new List<Volunteering>();
        }
    }
}
