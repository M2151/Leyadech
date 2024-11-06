using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class MotherService
    {
      
        public List<Mother> GetAllMothers()
        { 
            return DataContextManage.Lists.AllMothers;
            
        }
        public Mother GetMotherById(int id) 
        { 
            return DataContextManage.Lists.AllMothers.Where(m=>m.Id == id).FirstOrDefault<Mother>();
        }
        public bool AddMother(Mother mother)
        {
            mother.Id= DataContextManage.Lists.AllMothers.Max(mother=> mother.Id)+1;
            DataContextManage.Lists.AllMothers.Add(mother); return true;
        }
        public void SetMotherFields(Mother originalMo,Mother newMo)
        {

        }
        public bool UpdateMotherFields(int id, Mother mother) 
        { 
            Mother original = GetMotherById(id);
            if(original==default(Mother)) 
                return false;
            SetMotherFields(original, mother);
            return true;
        }
        public bool UpdateMotherStatus(int id,EMoterStatus status)
        {
            Mother mother = GetMotherById(id);
            if (mother == default(Mother))
                return false;
            mother.Status = status;
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
