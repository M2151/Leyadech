using Leyadech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();

        T? GetById(int id);

        bool Add(T entity);

        bool Delete(int id);

        bool Update(int id, T entity);
    }
}
