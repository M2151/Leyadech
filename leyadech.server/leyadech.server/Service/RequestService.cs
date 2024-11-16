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
        public List<HelpRequest> GetAllRequests() => _dataContext.RequestData;
        public List<HelpRequest> GetAllRelevantRequests() 
        {
            return _dataContext.RequestData.Where(req => req.IsRelevant).ToList();
        }
        public HelpRequest GetRequestById(int id) 
        {
            return _dataContext.RequestData.Find(req=>req.ApplicationId == id);
        }
        public bool IsMotherExist(int id) => _motherService.GetMotherById(id) != null;
        public bool IsRequiredFields(HelpRequest request)
        {
            if (request == null) return false;
            if (!IsMotherExist(request.UserId)) return false;
            if (request.HelpKind==null) return false;
            return true;
        }
        public bool IsValidFields(HelpRequest request)
        {
            return true;
        }
        public void SetRequest(HelpRequest original,HelpRequest newReq) 
        {

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
            SetRequest(original,request);
            return _dataContext.SaveRequestData();
        }
        public bool DeleteRequest(int id) 
        { 
            HelpRequest req= GetRequestById(id);
            _dataContext.RequestData.Remove(req);
            return _dataContext.SaveRequestData();
        }
        public bool AddRequest(HelpRequest request) 
        {
            if(!IsValidFields(request)) return false;
            _dataContext.LoadRequestData();
            request.ApplicationId = _dataContext.RequestData.Any() ? _dataContext.RequestData.Max(req => req.ApplicationId) + 1 : 1;
            request.ApplicationDate= DateTime.Now;
            _dataContext.RequestData.Add(request);
            return _dataContext.SaveRequestData();
        }
        public List<HelpRequest> GetReqByMotherId(int motherId)
        {
            return GetAllRequests()
                .Where(req=>req.UserId==motherId).ToList();
        }
    }
}
