using Leyadech.Core.Entities;
using System.Collections.Generic;

namespace Leyadech.Core.Services
{
    public interface IVolunteeringService
    {
        Result<IEnumerable<Volunteering>> GetAllVolunteerings();
        Result<Volunteering> GetVolunteeringById(int id);
        Result<bool> AddVolunteering(Volunteering volunteering);
        Result<bool> UpdateVolunteering(int id, Volunteering volunteering);
        Result<bool> DeleteVolunteering(int id);
    }
}
