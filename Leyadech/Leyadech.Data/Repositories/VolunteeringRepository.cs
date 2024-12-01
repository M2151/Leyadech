using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class VolunteeringRepository : IRepository<Volunteering>
    {
        private readonly DataContext _dataContext;

        public VolunteeringRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Volunteering> GetList()
        {
            return _dataContext.VolunteeringData;
        }

        public Volunteering? GetById(int id)
        {
            return _dataContext.VolunteeringData.Find(v => v.VolunteeringId == id);
        }

        public bool Add(Volunteering volunteering)
        {
            volunteering.VolunteeringId = _dataContext.VolunteeringData.Any()
                ? _dataContext.VolunteeringData.Max(v => v.VolunteeringId) + 1
                : 1;

            _dataContext.VolunteeringData.Add(volunteering);
            return _dataContext.SaveVolunteeringData();
        }

        public bool Delete(int id)
        {
            Volunteering? volunteering = GetById(id);
            if (volunteering == null) return false;

            _dataContext.VolunteeringData.Remove(volunteering);
            return _dataContext.SaveVolunteeringData();
        }

        public bool Update(int id, Volunteering volunteering)
        {
            Volunteering? original = GetById(id);
            if (original == null) return false;

            SetFields(original, volunteering);
            return _dataContext.SaveVolunteeringData();
        }

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
