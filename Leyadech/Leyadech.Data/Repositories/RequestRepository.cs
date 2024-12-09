using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(DataContext dataContext) : base(dataContext) { }
        
        private void SetFields(Request original, Request updated)
        {
            original.Frequency = updated.Frequency;
            original.UrgencyLevel = updated.UrgencyLevel;
            original.IsRelevant = updated.IsRelevant;
            original.Description = updated.Description;
            original.HelpKind = updated.HelpKind;
            original.Preferences = updated.Preferences;
        }
    }
}
