using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Data.Repositories
{
    public class MotherRepository : Repository<Mother>,IMotherRepository
    {

        public MotherRepository(DataContext dataContext):base(dataContext) { }
      
        //public bool AddSpecRequest(int id, string req)
        //{
        //    Mother? mother = GetById(id);
        //    if (mother == null) return false;
        //    mother.SpecialRequests.Add(req);
        //    return _dataContext.SaveMotherData();
        //}
  
    }
}
