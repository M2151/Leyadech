using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class VolunteerRepository : Repository<Volunteer>, IVolunteerRepository
    {

        public VolunteerRepository(DataContext dataContext) : base(dataContext) { }
        //public bool UpdateStatus(int id, EVolunteerStatus status)
        //{
        //    Volunteer? volunteer = GetById(id);
        //    if (volunteer == null) return false;
        //    volunteer.Status = status;
        //    return _dataContext.SaveVolunteerData();
        //}

       


       
    }
}
