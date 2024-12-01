using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class SuggestRepository : IRepository<Suggest>
    {
        private readonly DataContext _dataContext;

        public SuggestRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Suggest> GetList()
        {
            return _dataContext.SuggestData;
        }

        public Suggest? GetById(int id)
        {
            return _dataContext.SuggestData.Find(s => s.ApplicationId == id);
        }

        public bool Add(Suggest suggest)
        {
            // Assign a new ID if needed
            suggest.ApplicationId = _dataContext.SuggestData.Any()
                ? _dataContext.SuggestData.Max(s => s.ApplicationId) + 1
                : 1;

            _dataContext.SuggestData.Add(suggest);
            return _dataContext.SaveSuggestData();
        }

        public bool Delete(int id)
        {
            Suggest? suggest = GetById(id);
            if (suggest == null) return false;

            _dataContext.SuggestData.Remove(suggest);
            return _dataContext.SaveSuggestData();
        }

        public bool Update(int id, Suggest suggest)
        {
            Suggest? original = GetById(id);
            if (original == null) return false;

            SetFields(original, suggest);
            return _dataContext.SaveSuggestData();
        }

        private void SetFields(Suggest original, Suggest updated)
        {
            original.UserId = updated.UserId;
            original.Frequency = updated.Frequency;
            original.IsRelevant = updated.IsRelevant;
            original.Description = updated.Description;
            original.HelpKind = updated.HelpKind;
            original.Frequency = updated.Frequency;
            original.RelevantDays = updated.RelevantDays;
            original.IsFlexible = updated.IsFlexible;
        }
    }
}
