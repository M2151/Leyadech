using Leyadech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Core.Repositories
{
    public interface IMotherRepository
    {
         IEnumerable<Mother> GetList();

         Mother? GetById(int id);

         bool Add(Mother mother);

         bool Delete(int id);

         bool Update(int id, Mother mother);
         //bool AddSpecRequest(int id, string req);


    }
}
