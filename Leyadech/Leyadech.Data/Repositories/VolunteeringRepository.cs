using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class VolunteeringRepository : Repository<Volunteering>, IVolunteeringRepository
    {

        public VolunteeringRepository(DataContext dataContext) : base(dataContext) { }
        
        private void SetFields(Volunteering original, Volunteering updated)
        {
            original.Feedback = updated.Feedback;
            original.HelpFrequency = updated.HelpFrequency;
            original.TimeEnd = updated.TimeEnd;
            original.TimeStart = updated.TimeStart;
            original.DateStart = updated.DateStart;
            original.DateEnd = updated.DateEnd;
            original.Description = updated.Description;
            original.HelpKind = updated.HelpKind;
            original.RequestId = updated.RequestId;
            original.SuggestId = updated.SuggestId;
        }
    }
}
