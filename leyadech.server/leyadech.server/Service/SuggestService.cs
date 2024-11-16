using leyadech.server.DTO;

namespace leyadech.server.Service
{
    
    public class SuggestService
    {
        readonly IDataContext _dataContext;
        readonly VolunteerHelper _volunteerHelper;
        public SuggestService(IDataContext dataContext, VolunteerHelper volunteerHelper)
        {
            _dataContext = dataContext;
            _volunteerHelper = volunteerHelper;
            _dataContext.LoadSuggestData();
            
        }
        public List<HelpSuggest> GetAllSuggests() => _dataContext.SuggestData;
        public List<HelpSuggest> GetAllRelevantSuggests()
        {
            return _dataContext.SuggestData.Where(seg => seg.IsRelevant).ToList();
        }
        public HelpSuggest GetSuggestById(int id)
        {
            return _dataContext.SuggestData.Find(sug => sug.ApplicationId == id);
        }
        public void SetSuggest(HelpSuggest original, HelpSuggest newSug)
        {

            original.UserId = newSug.UserId;
            original.Frequency = newSug.Frequency;
            original.IsRelevant = newSug.IsRelevant;
            original.Description = newSug.Description;
            original.HelpKind = newSug.HelpKind;
            original.Frequency = newSug.Frequency;
            original.RelevantDays = newSug.RelevantDays;
            original.IsFlexible = newSug.IsFlexible;
        }
            
        public bool UpdateSuggest(int id, HelpSuggest suggest)
        {
            HelpSuggest original = GetSuggestById(id);
            if (original == null) return false;
            SetSuggest(original, suggest);
            return _dataContext.SaveSuggestData();

        }
        public bool IsVolExist(int id)
        {
            return _volunteerHelper.GetVolunteerById(id) != null;   
        }
        public bool IsValidFields(HelpSuggest suggest)
        {
            return true;
        }
        public bool IsRequiredFields(HelpSuggest suggest)
        {
            if (suggest == null) return false;
            Volunteer volunteer = _volunteerHelper.GetVolunteerById(suggest.UserId);
            if (volunteer == null) return false;
            return true;
        }
        public bool DeleteSuggest(int id)
        {
            HelpSuggest sug = GetSuggestById(id);
            _dataContext.SuggestData.Remove(sug);
            return _dataContext.SaveSuggestData();
        }
        public bool AddSuggest(HelpSuggest suggest)
        {
            _dataContext.LoadSuggestData();
            suggest.ApplicationId = _dataContext.SuggestData.Any() ? _dataContext.SuggestData.Max(sug => sug.ApplicationId) + 1 : 1;
            suggest.ApplicationDate = DateTime.Now;
            _dataContext.SuggestData.Add(suggest);
            return _dataContext.SaveSuggestData();
        }
        public List<HelpSuggest> GetSegByVolId(int volId)
        {
            return GetAllRelevantSuggests()
                .Where(sug => sug.UserId == volId).ToList();
        }
    }
}
