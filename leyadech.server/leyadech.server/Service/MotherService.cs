using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class MotherService:UserService
    {
        readonly IDataContext _dataContext;
        public MotherService(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _dataContext.LoadMotherData();
        }
        public List<Mother> GetAllMothers()
        {
            return _dataContext.MotherData;
            
        }
        public Mother GetMotherById(int id) 
        { 
            return _dataContext.MotherData.Find(m=>m.Id == id);
        }
        public void SetMotherStatus(Mother mother)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (mother.BirthDate.AddMonths(1) > today)
                mother.Status = EMoterStatus.WeekAfterBirth;
            else if (mother.BirthDate.AddMonths(2) > today)
                mother.Status = EMoterStatus.MonthAfterBirth;
            else if (mother.BirthDate.AddMonths(4) > today)
                mother.Status = EMoterStatus.LongAfterBirth;
        }
        public bool AddMother(Mother mother)
        {
            
            if (!IsValidFields(mother)) return false;
            mother.Id= _dataContext.MotherData.Max(mother=> mother.Id)+1;
            SetMotherStatus(mother);
            _dataContext.MotherData.Add(mother); 
            return _dataContext.SaveMotherData();
        }
        public void SetMotherFields(Mother originalMo,Mother newMo)
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
       
        public bool IsValidFields(Mother mother)
        {
            if (mother == null) return false;
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (mother.JoinDate>today)return false;
            if (mother.BirthDate > today) return false;
            if(mother.ChildrenBelow7>mother.FamilySize) return false;
            if(!IsvalidEmail(mother.Email)) return false;
            if(!IsValidPhone(mother.PhoneNumber)) return false;
            return true;
        }
        public bool UpdateMotherFields(int id, Mother mother) 
        { 
            Mother original = GetMotherById(id);
            if(original==default(Mother)) 
                return false;
            SetMotherFields(original, mother);
            return _dataContext.SaveMotherData();
        }
        
        public bool DeleteMother(int id) 
        { 
            Mother mother = GetMotherById(id);
            if(mother==default(Mother)) return false;
            _dataContext.MotherData.Remove(mother);
            return _dataContext.SaveMotherData();
        }
        public bool AddSpecialRequest(int id,string request)
        {
            Mother mother = GetMotherById(id);
            if (mother == default(Mother)) return false;
            mother.SpecialRequests.Add(request);
            return _dataContext.SaveMotherData();
        }
     
    }
}
