using Leyadech.Core.Entities;

namespace Leyadech.Core.Repositories
{
    public interface IVolunteeringRepository
    {
        IEnumerable<Volunteering> GetList();
        Volunteering? GetById(int id);
        bool Add(Volunteering volunteering);
        bool Delete(int id);
        bool Update(int id, Volunteering volunteering);
    }
}
