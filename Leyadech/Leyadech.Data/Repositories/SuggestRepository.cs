using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class SuggestRepository : Repository<Suggest>, ISuggestRepository
    {

        public SuggestRepository(DataContext dataContext) : base(dataContext) { }
        
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
