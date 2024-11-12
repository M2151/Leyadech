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
            try
            {
                Mother mother = new Mother() { Id = 1, Address = "sdsfsd", Email = "m1233@gmail.com", JoinDate = DateOnly.FromDateTime(DateTime.Now) };
                MotherData = new List<Mother> { mother };
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool LoadRequestData()
        {
            throw new NotImplementedException();
        }

        public bool LoadSuggestData()
        {
            throw new NotImplementedException();
        }

        public bool LoadVolunteerData()
        {
            throw new NotImplementedException();
        }

        public bool LoadVolunteeringData()
        {
            throw new NotImplementedException();
        }

        public bool SaveMotherData()
        {
            return true;
        }


        public bool SaveRequestData()
        {
            throw new NotImplementedException();
        }


        public bool SaveSuggestData()
        {
            throw new NotImplementedException();
        }

      

        public bool SaveVolunteerData()
        {
            throw new NotImplementedException();
        }


        public bool SaveVolunteeringData()
        {
            throw new NotImplementedException();
        }

        

     
    }
}
