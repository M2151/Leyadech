using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class RequestService
    {
        List<HelpRequest> _allRequests;
        public List<HelpRequest> GetAllRequests() 
        {
            return _allRequests.Where(req => req.IsRelevant);
        }
        public HelpRequest GetRequestById(int id) 
        {
            return _allRequests.Find(req=>req.Id == id);
        }
        public bool UpdateRequest(int id, HelpRequest request) 
        { 

        }
        public bool DeleteRequest(int id) { }
        public bool AddRequest(HelpRequest request) { }
    }
}
