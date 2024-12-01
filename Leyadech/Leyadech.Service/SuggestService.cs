using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System.Collections.Generic;

namespace Leyadech.Service
{
    public class SuggestService : ISuggestService
    {
        private readonly IRepository<Suggest> _suggestRepository;
        private readonly IRepository<Volunteer> _volunteerRepository;

        public SuggestService(IRepository<Suggest> suggestRepository, IRepository<Volunteer> volunteerRepository)
        {
            _suggestRepository = suggestRepository;
            _volunteerRepository = volunteerRepository;
        }

        public Result<IEnumerable<Suggest>> GetAllSuggests()
        {
            var suggests = _suggestRepository.GetList();
            return Result<IEnumerable<Suggest>>.Success(suggests);
        }

        public Result<Suggest> GetSuggestById(int id)
        {
            var suggest = _suggestRepository.GetById(id);
            if (suggest == null)
                return Result<Suggest>.NotFound($"Suggest with Id {id} not found");

            return Result<Suggest>.Success(suggest);
        }

        public Result<bool> AddSuggest(Suggest suggest)
        {
            if (suggest == null)
                return Result<bool>.BadRequest("Cannot add null Suggest");

            if (!IsValidFields(suggest))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (!IsRequiredFields(suggest))
                return Result<bool>.BadRequest("One or more required fields are missing");

            var success = _suggestRepository.Add(suggest);
            if (!success)
                return Result<bool>.Failure("Failed to add Suggest");

            return Result<bool>.Success(true);
        }

        public Result<bool> UpdateSuggest(int id, Suggest suggest)
        {
            if (suggest == null)
                return Result<bool>.BadRequest("Cannot update null Suggest");

            var existingSuggest = _suggestRepository.GetById(id);
            if (existingSuggest == null)
                return Result<bool>.NotFound($"Suggest with Id {id} not found");

            if (!IsValidFields(suggest))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (!IsRequiredFields(suggest))
                return Result<bool>.BadRequest("One or more required fields are missing");
            var success = _suggestRepository.Update(id, suggest);
            if (!success)
                return Result<bool>.Failure("Failed to update Suggest");

            return Result<bool>.Success(true);
        }

        public Result<bool> DeleteSuggest(int id)
        {
            var existingSuggest = _suggestRepository.GetById(id);
            if (existingSuggest == null)
                return Result<bool>.NotFound($"Suggest with Id {id} not found");

            var success = _suggestRepository.Delete(id);
            if (!success)
                return Result<bool>.Failure("Failed to delete Suggest");

            return Result<bool>.Success(true);
        }

        private bool IsValidFields(Suggest suggest)
        {
            if (_volunteerRepository.GetById(suggest.UserId) == null) return false;
            return true;
        }
        private bool IsRequiredFields(Suggest suggest)
        {
            if (suggest == null) return false;
            return true;
        }
    }
}
