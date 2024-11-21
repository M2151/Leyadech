using Leyadech.Core.Entities;

namespace Leyadech.Core.Repositories
{
    public interface IVolunteerRepository
    {
        IEnumerable<Volunteer> GetList();
        Volunteer? GetById(int id);
        bool Add(Volunteer volunteer);
        bool Delete(int id);
        bool Update(int id, Volunteer volunteer);
       // bool UpdateStatus(int id, EVolunteerStatus status);

    }
}
