using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leyadech.Service
{
    public class MotherService : UserService, IMotherService
    {
        private readonly IRepository<Mother> _motherRepository;
        public MotherService(IRepository<Mother> motherRepository)
        {
            _motherRepository = motherRepository;
        }
        public Result<IEnumerable<Mother>> GetAllMothers()
        {
            return Result<IEnumerable<Mother>>.Success(_motherRepository.GetList());

        }
        public Result<Mother> GetMotherById(int id)
        {
            var mother = _motherRepository.GetById(id);
            if (mother == null)
                return Result<Mother>.NotFound("mother not found");
            return Result<Mother>.Success(mother);
        }

        public Result<bool> AddMother(Mother mother)
        {
            if (mother == null)
                return Result<bool>.BadRequest("Cannot add mother of null reference");
            if (!IsRequiredFields(mother))
                return Result<bool>.BadRequest("One or more required fields are missing");
            if (!IsValidFields(mother))
                return Result<bool>.BadRequest("One or more fields are not valid");
            mother.JoinDate = DateOnly.FromDateTime(DateTime.Today);
            SetMotherStatus(mother);
            if (mother.SpecialRequests == null)
                mother.SpecialRequests = new List<string>();
            var result = _motherRepository.Add(mother);
            if (!result)
                return Result<bool>.Failure("Failed to add mother");
            return Result<bool>.Success(result);
        }
        public Result<bool> UpdateMother(int id, Mother mother)
        {
            if (mother == null)
                return Result<bool>.BadRequest("Cannot update mother to null reference");
            if (!IsRequiredFields(mother))
                return Result<bool>.BadRequest("One or more required fields are missing");
            if (!IsValidFields(mother))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (_motherRepository.GetById(id) == null)
                return Result<bool>.NotFound($"Id {id} is not found");
            var result = _motherRepository.Update(id, mother);
            if (result) return Result<bool>.Success(result);
            return Result<bool>.Failure("Failed to update mother");
        }
        public Result<bool> DeleteMother(int id)
        {
            if (_motherRepository.GetById(id) == null)
                return Result<bool>.NotFound($"Id {id} is not found");
            var result = _motherRepository.Delete(id);
            if (result) return Result<bool>.Success(result);
            return Result<bool>.Failure("Failed to delete mother");
        }
        //public Result<bool> AddSpecialRequest(int id, string request)
        //{
        //    var mother = _motherRepository.GetById(id);
        //    if (mother == null) return Result<bool>.NotFound($"Id {id} is not found");
        //    if (mother.SpecialRequests == null)
        //        mother.SpecialRequests = new List<string>();
        //    var result=_motherRepository.AddSpecRequest(id, request);
        //    return Result<bool>.Success(true);
        //}
        public bool IsValidFields(Mother mother)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (mother.JoinDate > today) return false;
            if (mother.BirthDate > today) return false;
            if (mother.ChildrenBelow7 > mother.FamilySize) return false;
            if (!IsvalidEmail(mother.Email)) return false;
            if (!IsValidPhone(mother.PhoneNumber)) return false;
            return true;
        }
        private bool IsRequiredFields(Mother mother)
        {
            if (mother.Email == null) return false;
            if (!mother.BirthDate.HasValue) return false;
            return true;
        }
        private void SetMotherStatus(Mother mother)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (mother.BirthDate.Value.AddMonths(1) > today)
                mother.Status = EMoterStatus.WeekAfterBirth;
            else if (mother.BirthDate.Value.AddMonths(2) > today)
                mother.Status = EMoterStatus.MonthAfterBirth;
            else if (mother.BirthDate.Value.AddMonths(4) > today)
                mother.Status = EMoterStatus.LongAfterBirth;

        }



    }
}
