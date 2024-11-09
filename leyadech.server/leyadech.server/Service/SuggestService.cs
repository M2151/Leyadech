using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class SuggestService
    {
     
        public List<HelpSuggest> GetAllSuggests() => DataContextManage.Lists.AllSuggests;
        public List<HelpSuggest> GetAllRelevantSuggests()
        {
            return DataContextManage.Lists.AllSuggests.Where(seg => seg.IsRelevant).ToList();
        }
        public HelpSuggest GetSuggestById(int id)
        {
            return DataContextManage.Lists.AllSuggests.Find(sug => sug.ApplicationId == id);
        }
        public bool SetSuggest(HelpSuggest original, HelpSuggest newSug)
        {
            if (newSug == null) return false;
            original.UserId = newSug.UserId;
            original.Frequency = newSug.Frequency;
            original.IsRelevant = newSug.IsRelevant;
            original.Description = newSug.Description;
            original.HelpKind = newSug.HelpKind;
            original.Frequency= newSug.Frequency;
            original.RelevantDays= newSug.RelevantDays;
            original.IsFlexible= newSug.IsFlexible;
            return true;
        }
        public bool UpdateSuggest(int id, HelpSuggest suggest)
        {
            HelpSuggest original = GetSuggestById(id);
            if (original == null) return false;
            return SetSuggest(original, suggest);

        }
        public bool IsValidFields(HelpSuggest suggest)
        {
            if (suggest == null) return false;
            VolunteerService volunteerService = new VolunteerService();
            Volunteer volunteer = volunteerService.GetVolunteerById(suggest.UserId);
            if (volunteer == null) return false;
            return true;
        }
        public bool DeleteSuggest(int id)
        {
            HelpSuggest sug = GetSuggestById(id);
            if (sug == null) return false;
            DataContextManage.Lists.AllSuggests.Remove(sug);
            return true;
        }
        public bool AddSuggest(HelpSuggest suggest)
        {
            if (!IsValidFields(suggest)) return false;
            DataContextManage.Lists.AllSuggests.Add(suggest);
            return true;
        }
        public List<HelpSuggest> GetSegByVolId(int volId)
        {
            return GetAllRelevantSuggests()
                .Where(sug => sug.UserId == volId).ToList();
        }
    }
}
