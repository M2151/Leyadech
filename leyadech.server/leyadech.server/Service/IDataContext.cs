using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public interface IDataContext
    {
        public List<Mother> MotherData { get; set; }
        public List<Volunteer> VolunteerData { get; set; }
        public List<HelpRequest> RequestData { get; set; }
        public List<HelpSuggest> SuggestData { get; set; }
        public List<Volunteering> VolunteeringData { get; set; }
        public bool LoadMotherData();
        public bool SaveMotherData();
        public bool LoadVolunteerData();
        public bool SaveVolunteerData();
        public bool LoadRequestData();
        public bool SaveRequestData();
        public bool LoadSuggestData();
        public bool SaveSuggestData();          
        public bool LoadVolunteeringData();
        public bool SaveVolunteeringData();
    }
}
