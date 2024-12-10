using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Leyadech.Data.Repositories
{
    public class VolunteeringRepository : Repository<Volunteering>, IVolunteeringRepository
    {

        public VolunteeringRepository(DataContext dataContext) : base(dataContext) { }
        
   
    }
}
