using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class RequestService
    {
        readonly IDataContext _dataContext;
        readonly MotherService _motherService;
        public RequestService(IDataContext dataContext,MotherService motherService)
        {
            _dataContext = dataContext;
            _dataContext.LoadRequestData();
            _motherService = motherService;
        }
        public List<HelpRequest> GetAllRequests() => DataContextManage.Lists.AllRequests;
        public List<HelpRequest> GetAllRelevantRequests() 
        {
            return _dataContext.RequestData.Where(req => req.IsRelevant).ToList();
        }
        public HelpRequest GetRequestById(int id) 
        {
            return _dataContext.RequestData.Find(req=>req.ApplicationId == id);
        }
        public bool IsValidFields(HelpRequest request)
        {
            if (request == null) return false;
            Mother mother = _motherService.GetMotherById(request.UserId);
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
            return _dataContext.SaveRequestData();
        }
        public bool DeleteRequest(int id) 
        { 
            HelpRequest req= GetRequestById(id);
            if(req==null)return false;
            _dataContext.RequestData.Remove(req);
            return _dataContext.SaveRequestData();
        }
        public bool AddRequest(HelpRequest request) 
        {
            if(!IsValidFields(request)) return false;
            _dataContext.RequestData.Add(request);
            return _dataContext.SaveRequestData();
        }
        public List<HelpRequest> GetReqByMotherId(int motherId)
        {
            return GetAllRelevantRequests()
                .Where(req=>req.UserId==motherId).ToList();
        }
    }
}
