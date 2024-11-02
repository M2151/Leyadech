using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class MotherService
    {
        List<Mother> _allMothers;
        public List<Mother> GetAllMothers()
        { 
            return _allMothers;
        }
        public Mother GetMotherById(int id) 
        { 
            return _allMothers.Where(m=>m.Id == id).FirstOrDefault<Mother>();
        }
        public bool AddMother(Mother mother)
        {
            mother.Id=_allMothers.Max(mother=> mother.Id)+1;
            _allMothers.Add(mother); return true;
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
            _allMothers.Remove(mother);
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
