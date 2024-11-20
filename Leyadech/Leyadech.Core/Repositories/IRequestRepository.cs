using Leyadech.Core.Entities;

namespace Leyadech.Core.Repositories
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetList();
        Request? GetById(int id);
        bool Add(Request request);
        bool Delete(int id);
        bool Update(int id, Request request);
    }
}
