using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class RequestService
    {
        
        public List<HelpRequest> GetAllRequests() => DataContextManage.Lists.AllRequests;
        public List<HelpRequest> GetAllRelevantRequests() 
        {
            return DataContextManage.Lists.AllRequests.Where(req => req.IsRelevant).ToList();
        }
        public HelpRequest GetRequestById(int id) 
        {
            return DataContextManage.Lists.AllRequests.Find(req=>req.ApplicationId == id);
        }
        public bool IsValidFields(HelpRequest request)
        {
            if (request == null) return false;
            MotherService motherService = new MotherService();
            Mother mother = motherService.GetMotherById(request.UserId);
            if (mother == null) return false;
            return true;
        }
        public void SetRequest(HelpRequest original,HelpRequest newReq) 
        {
            
            original.UserId = newReq.UserId;
            original.Frequency = newReq.Frequency;
            original.UrgencyLevel = newReq.UrgencyLevel;
            original.IsRelevant = newReq.IsRelevant;
            original.Description = newReq.Description;
            original.HelpKind = newReq.HelpKind;
            original.Preferences = newReq.Preferences;
          
        }
        public bool UpdateRequest(int id, HelpRequest request) 
        { 
            HelpRequest original= GetRequestById(id);
            if(original==null) return false;
            SetRequest(original,request);
            return true;
        }
        public bool DeleteRequest(int id) 
        { 
            HelpRequest req= GetRequestById(id);
            if(req==null)return false;
            DataContextManage.Lists.AllRequests.Remove(req);
            return true;
        }
        public bool AddRequest(HelpRequest request) 
        {
            if(!IsValidFields(request)) return false;
            DataContextManage.Lists.AllRequests.Add(request);
            return true;
        }
        public List<HelpRequest> GetReqByMotherId(int motherId)
        {
            return GetAllRelevantRequests()
                .Where(req=>req.UserId==motherId).ToList();
        }
    }
}
