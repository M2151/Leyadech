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
        private void SetFields(Mother originalMo, Mother newMo)
        {
            originalMo.Address = newMo.Address;
            originalMo.Email = newMo.Email;
            originalMo.FirstName = newMo.FirstName;
            originalMo.LastName = newMo.LastName;
            originalMo.ChildrenBelow7 = newMo.ChildrenBelow7;
            originalMo.FamilySize = newMo.FamilySize;
            originalMo.PhoneNumber = newMo.PhoneNumber;
            originalMo.HelpKindNeeded = newMo.HelpKindNeeded;
            originalMo.IsStandingOrder = newMo.IsStandingOrder;

        }
    }
}
