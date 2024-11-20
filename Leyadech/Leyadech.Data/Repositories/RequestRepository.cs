using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _dataContext;

        public RequestRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Request> GetList()
        {
            return _dataContext.RequestData;
        }

        public Request? GetById(int id)
        {
            return _dataContext.RequestData.Find(r => r.ApplicationId == id);
        }

        public bool Add(Request request)
        {
            // Assign a new ID if needed
            request.ApplicationId = _dataContext.RequestData.Any()
                ? _dataContext.RequestData.Max(r => r.ApplicationId) + 1
                : 1;

            _dataContext.RequestData.Add(request);
            return _dataContext.SaveRequestData();
        }

        public bool Delete(int id)
        {
            Request? request = GetById(id);
            if (request == null) return false;

            _dataContext.RequestData.Remove(request);
            return _dataContext.SaveRequestData();
        }

        public bool Update(int id, Request request)
        {
            Request? original = GetById(id);
            if (original == null) return false;

            SetFields(original, request);
            return _dataContext.SaveRequestData();
        }

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
