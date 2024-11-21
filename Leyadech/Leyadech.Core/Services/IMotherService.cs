using Leyadech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Core.Services
{
    public interface IMotherService
    {
        public Result<IEnumerable<Mother>> GetAllMothers();
        public Result<Mother> GetMotherById(int id);
        public Result<bool> AddMother(Mother mother);
        public Result<bool> UpdateMother(int id, Mother mother);
        public Result<bool> DeleteMother(int id);
        //public Result<bool> AddSpecialRequest(int id, string request);




    }
}
