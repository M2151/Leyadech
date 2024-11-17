using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class FakeContext : IDataContext
    {
        public List<Mother> MotherData { get; set; }
        public List<Volunteer> VolunteerData { get; set; }
        public List<HelpRequest> RequestData { get; set; }
        public List<HelpSuggest> SuggestData { get; set; }
        public List<Volunteering> VolunteeringData { get; set; }

        public bool LoadMotherData()
        {
            Mother mother = new Mother() { Id = 1, Address = "sdsfsd", Email = "m1233@gmail.com", JoinDate = DateOnly.FromDateTime(DateTime.Now) };
            MotherData = new List<Mother> { mother };
            return true;
        }

        public bool LoadRequestData()
        {
           HelpRequest req = new HelpRequest() { ApplicationId = 1, UserId = 1, Description = "qqqq" ,HelpKind=EHelpKind.Babysitting}; 
           RequestData = new List<HelpRequest> { req };
           return true;
        }

        public bool LoadSuggestData()
        {
            HelpSuggest sug=new HelpSuggest() { HelpKind = EHelpKind.Babysitting ,ApplicationId=1,UserId=1};
            SuggestData=new List<HelpSuggest> { sug };
            return true;
        }

        public bool LoadVolunteerData()
        {
            Volunteer volunteer = new Volunteer() { Id = 1, Email = "m0556777068@gmail.com" };
            VolunteerData =new List<Volunteer> { volunteer };
            return true;
        }

        public bool LoadVolunteeringData()
        {
            Volunteering volunteering = new Volunteering() { VolunteeringId = 1 };
            VolunteeringData =new List<Volunteering> {  volunteering };
            return true;
        }

        public bool SaveMotherData()
        {
            return true;
        }


        public bool SaveRequestData()
        {
            return true;
        }


        public bool SaveSuggestData()
        {
            return true;
        }



        public bool SaveVolunteerData()
        {
            return true;
        }


        public bool SaveVolunteeringData()
        {
            return true;
        }




    }
}
