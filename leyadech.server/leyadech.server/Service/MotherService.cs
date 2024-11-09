using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class MotherService:UserService
    {
      
        public List<Mother> GetAllMothers()
        { 
            return DataContextManage.Lists.AllMothers;
            
        }
        public Mother GetMotherById(int id) 
        { 
            return DataContextManage.Lists.AllMothers.Find(m=>m.Id == id);
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
            if(!IsValidFields(mother)) return false;
            mother.Id= DataContextManage.Lists.AllMothers.Max(mother=> mother.Id)+1;
            SetMotherStatus(mother);
            DataContextManage.Lists.AllMothers.Add(mother); 
            return true;
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
            return true;
        }
        
        public bool DeleteMother(int id) 
        { 
            Mother mother = GetMotherById(id);
            if(mother==default(Mother)) return false;
            DataContextManage.Lists.AllMothers.Remove(mother);
            return true;
        }
        public bool AddSpecialRequest(int id,string request)
        {
            Mother mother = GetMotherById(id);
            if (mother == default(Mother)) return false;
            mother.SpecialRequests.Add(request);
            return true;
        }
     
    }
}
