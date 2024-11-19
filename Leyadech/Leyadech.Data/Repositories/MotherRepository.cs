using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Data.Repositories
{
    public class MotherRepository:IMotherRepository
    {
        private readonly DataContext _dataContext;
        public MotherRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Mother> GetList()
        {
            return _dataContext.MotherData;
        }
        public Mother? GetById(int id)
        {
            return _dataContext.MotherData.Find(m => m.Id == id);
        }
        public bool Add(Mother mother)
        {
            _dataContext.MotherData.Add(mother);
            return _dataContext.SaveMotherData();
        }
        public bool Delete(int id)
        {
            Mother? mother = GetById(id);
            if (mother == null) return false;
            _dataContext.MotherData.Remove(mother);
            return _dataContext.SaveMotherData();
        }
        public bool Update(int id, Mother mother)
        {
            Mother? original = GetById(id);
            if (original == null) return false;
            SetFields(original, mother);
            return _dataContext.SaveMotherData();
        }
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
