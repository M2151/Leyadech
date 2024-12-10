using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System.Collections.Generic;

namespace Leyadech.Service
{
    public class VolunteeringService : IVolunteeringService
    {
        private readonly IRepositoryManager _repositoryManager;


        public VolunteeringService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Result<IEnumerable<Volunteering>> GetAllVolunteerings()
        {
            var volunteerings = _repositoryManager.Volunteerings.GetList();
            return Result<IEnumerable<Volunteering>>.Success(volunteerings);
        }

        public Result<Volunteering> GetVolunteeringById(int id)
        {
            var volunteering = _repositoryManager.Volunteerings.GetById(id);
            if (volunteering == null)
                return Result<Volunteering>.NotFound($"Volunteering with Id {id} not found");

            return Result<Volunteering>.Success(volunteering);
        }

        public Result<bool> AddVolunteering(Volunteering volunteering)
        {
            if (volunteering == null)
                return Result<bool>.BadRequest("Cannot add null Volunteering");

            if (!IsValidFields(volunteering))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (!IsRequiredFields(volunteering))
                return Result<bool>.BadRequest("One or more required fields are missing");

            var success = _repositoryManager.Volunteerings.Add(volunteering);
            if (success == null)
                return Result<bool>.Failure("Failed to add Volunteering");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        public Result<bool> UpdateVolunteering(int id, Volunteering volunteering)
        {
            if (volunteering == null)
                return Result<bool>.BadRequest("Cannot update null Volunteering");

            var existingVolunteering = _repositoryManager.Volunteerings.GetById(id);
            if (existingVolunteering == null)
                return Result<bool>.NotFound($"Volunteering with Id {id} not found");

            if (!IsValidFields(volunteering))
                return Result<bool>.BadRequest("One or more fields are not valid");


            var success = _repositoryManager.Volunteerings.Update(id, volunteering);
            if (success == null)
                return Result<bool>.Failure("Failed to update Volunteering");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        public Result<bool> DeleteVolunteering(int id)
        {
            var existingVolunteering = _repositoryManager.Volunteerings.GetById(id);
            if (existingVolunteering == null)
                return Result<bool>.NotFound($"Volunteering with Id {id} not found");

            var success = _repositoryManager.Volunteerings.Delete(id);
            if (!success)
                return Result<bool>.Failure("Failed to delete Volunteering");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        private bool IsValidFields(Volunteering vol)
        {
            if (vol.DateEnd < vol.DateStart)
                return false;
            if (vol.DateStart != null && DateOnly.FromDateTime(DateTime.Now) > vol.DateStart)
                return false;
            if (vol.TimeEnd < vol.TimeStart)
                return false;
            if (_repositoryManager.Suggests.GetById(vol.SuggestId) == null) return false;
            if (_repositoryManager.Requests.GetById(vol.RequestId) == null) return false;
            return true;
        }
        private bool IsRequiredFields(Volunteering vol)
        {
            if (vol == null) return false;
            return true;
        }
    }
}
