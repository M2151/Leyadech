using Leyadech.Core.Entities;

namespace Leyadech.Core.Repositories
{
    public interface ISuggestRepository
    {
        IEnumerable<Suggest> GetList();
        Suggest? GetById(int id);
        bool Add(Suggest suggest);
        bool Delete(int id);
        bool Update(int id, Suggest suggest);
    }
}
