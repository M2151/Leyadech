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
        public IEnumerable<Mother> GetList();

        public Mother? GetById(int id);

        public bool Add(Mother mother);

        public bool Delete(int id);

        public bool Update(int id,Mother mother);
        
    }
}
