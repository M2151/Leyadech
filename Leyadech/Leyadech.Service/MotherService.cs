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
        private readonly IRepositoryManager _repositoryManager;
        public MotherService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public Result<IEnumerable<Mother>> GetAllMothers()
        {
            return Result<IEnumerable<Mother>>.Success(_repositoryManager.Mothers.GetList());

        }
        public Result<Mother> GetMotherById(int id)
        {
            var mother = _repositoryManager.Mothers.GetById(id);
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
            var result = _repositoryManager.Mothers.Add(mother);
            if (result==null)
                return Result<bool>.Failure("Failed to add mother");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }
        public Result<bool> UpdateMother(int id, Mother mother)
        {
            if (mother == null)
                return Result<bool>.BadRequest("Cannot update mother to null reference");
            if (!IsValidFields(mother))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (_repositoryManager.Mothers.GetById(id) == null)
                return Result<bool>.NotFound($"Id {id} is not found");
            var result = _repositoryManager.Mothers.Update(id, mother);
            if (result == null) return Result<bool>.Failure("Failed to update mother");
            _repositoryManager.Save();
            return Result<bool>.Success(true);

        }
        public Result<bool> DeleteMother(int id)
        {
            if (_repositoryManager.Mothers.GetById(id) == null)
                return Result<bool>.NotFound($"Id {id} is not found");
            var result = _repositoryManager.Mothers.Delete(id);
            if (!result) return Result<bool>.Failure("Failed to delete mother");
            _repositoryManager.Save();
            return Result<bool>.Success(result);
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
