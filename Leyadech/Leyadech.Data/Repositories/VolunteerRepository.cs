using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly DataContext _dataContext;

        public VolunteerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Volunteer> GetList()
        {
            return _dataContext.VolunteerData;
        }

        public Volunteer? GetById(int id)
        {
            return _dataContext.VolunteerData.FirstOrDefault(v => v.Id == id);
        }

        public bool Add(Volunteer volunteer)
        {
            volunteer.Id = _dataContext.VolunteerData.Any()
                ? _dataContext.VolunteerData.Max(v => v.Id) + 1
                : 1;

            _dataContext.VolunteerData.Add(volunteer);
            return _dataContext.SaveVolunteerData();
        }

        public bool Delete(int id)
        {
            Volunteer? volunteer = GetById(id);
            if (volunteer == null) return false;

            _dataContext.VolunteerData.Remove(volunteer);
            return _dataContext.SaveVolunteerData();
        }

        public bool Update(int id, Volunteer volunteer)
        {
            Volunteer? original = GetById(id);
            if (original == null) return false;

            SetFields(original, volunteer);
            return _dataContext.SaveVolunteerData();
        }

        private void SetFields(Volunteer original, Volunteer updated)
        {
            original.Email = updated.Email;
            original.FirstName = updated.FirstName;
            original.LastName = updated.LastName;
            original.PhoneNumber = updated.PhoneNumber;
            original.Address = updated.Address;
            original.HelpKindSuggested = updated.HelpKindSuggested;
            original.Status = updated.Status;
        }

        public bool UpdateStatus(int id, EVolunteerStatus status)
        {
            Volunteer? volunteer = GetById(id);
            if (volunteer == null) return false;
            volunteer.Status = status;
            return _dataContext.SaveVolunteerData();
        }
    }
}
