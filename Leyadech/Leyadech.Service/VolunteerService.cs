using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Service
{

    public class VolunteerService : UserService,IVolunteerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public VolunteerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public Result<IEnumerable<Volunteer>> GetAllVolunteers()
        {
            return Result<IEnumerable<Volunteer>>.Success(_repositoryManager.Volunteers.GetList());
        }
        public Result<Volunteer> GetVolunteerById(int id)
        {
            var volunteer = _repositoryManager.Volunteers.GetById(id);
            if (volunteer == null) return Result<Volunteer>.NotFound("volunteer not found");
            return Result<Volunteer>.Success(volunteer);
        }
        public Result<bool> AddVolunteer(Volunteer volunteer)
        {
            if (volunteer == null)
                return Result<bool>.BadRequest("Cannot add volunteer of null reference");
            if (!IsRequiredFields(volunteer))
                return Result<bool>.BadRequest("One or more required fields are missing");
            if (!IsValidFields(volunteer))
                return Result<bool>.BadRequest("One or more fields are not valid");
            volunteer.JoinDate = DateOnly.FromDateTime(DateTime.Now);
            var result = _repositoryManager.Volunteers.Add(volunteer);
            if (result == null)
                return Result<bool>.Failure("Failed to add volunteer");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }
        public Result<bool> UpdateVolunteer(int id, Volunteer volunteer)
        {
            if (volunteer == null)
                return Result<bool>.BadRequest("Cannot update mother to null reference");

            if (!IsValidFields(volunteer))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (_repositoryManager.Volunteers.GetById(id) == null)
                return Result<bool>.NotFound($"Id {id} is not found");
            var result = _repositoryManager.Volunteers.Update(id, volunteer);
            if (result==null) return Result<bool>.BadRequest("Failed to update volunteer");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        public Result<bool> DeleteVolunteer(int id)
        {
            var volunteer = _repositoryManager.Volunteers.GetById(id);
            if (volunteer == null) return Result<bool>.NotFound($"Id {id} is not found"); 
            var result = _repositoryManager.Volunteers.Delete(id);
            if (!result) return Result<bool>.BadRequest("Failed to delete volunteer");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        //public Result<bool> UpdateVolunteerStatus(int id, EVolunteerStatus status)
        //{
        //    if (_volunteerRepository.GetById(id) == null)
        //        return Result<bool>.NotFound($"Id {id} is not found");
        //    var result = _volunteerRepository.UpdateStatus(id, status);
        //    if (result) return Result<bool>.Success(true);
        //    return Result<bool>.Failure("Failed to update status");
        //}
        public Result<IEnumerable<Volunteering>> GetAllVolunteeringsById(int id)
        {
            var result = _repositoryManager.Volunteerings.GetList()
                .Where(vol => _repositoryManager.Suggests.GetById(vol.SuggestId)?.UserId == id)
                ?.ToList();
            if (result == null)
                return Result<IEnumerable<Volunteering>>.NotFound($"Id {id} is not found");
            return Result<IEnumerable<Volunteering>>.Success(result);
        }
        private bool IsRequiredFields(Volunteer volunteer)
        {
            if (volunteer == null) return false;
            if (volunteer.Email == null) return false;
            return true;
        }
        private bool IsValidFields(Volunteer volunteer)
        {
            if (volunteer == null) return false;
            if (!IsvalidEmail(volunteer.Email)) return false;
            if (!IsValidPhone(volunteer.PhoneNumber)) return false;
            return true;
        }

    }
}


