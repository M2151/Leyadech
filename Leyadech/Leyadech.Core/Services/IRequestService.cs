using Leyadech.Core.Entities;
using System.Collections.Generic;

namespace Leyadech.Core.Services
{
    public interface IRequestService
    {
        Result<IEnumerable<Request>> GetAllRequests();
        Result<Request> GetRequestById(int id);
        Result<bool> AddRequest(Request request);
        Result<bool> UpdateRequest(int id, Request request);
        Result<bool> DeleteRequest(int id);
    }
}
