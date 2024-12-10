using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System.Collections.Generic;

namespace Leyadech.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRepositoryManager _repositoryManager;
        public RequestService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Result<IEnumerable<Request>> GetAllRequests()
        {
            var requests = _repositoryManager.Requests.GetList();
            return Result<IEnumerable<Request>>.Success(requests);
        }

        public Result<Request> GetRequestById(int id)
        {
            var request = _repositoryManager.Requests.GetById(id);
            if (request == null)
                return Result<Request>.NotFound($"Request with Id {id} not found");
            _repositoryManager.Save();
            return Result<Request>.Success(request);
        }

        public Result<bool> AddRequest(Request request)
        {
            if (request == null)
                return Result<bool>.BadRequest("Cannot add null Request");

            if (!IsValidFields(request))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (!IsRequiredFields(request))
                return Result<bool>.BadRequest("One or more required fields are missing");

            var success = _repositoryManager.Requests.Add(request);
            if (success == null)
                return Result<bool>.Failure("Failed to add Request");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        public Result<bool> UpdateRequest(int id, Request request)
        {
            if (request == null)
                return Result<bool>.BadRequest("Cannot update null Request");

            var existingRequest = _repositoryManager.Requests.GetById(id);
            if (existingRequest == null)
                return Result<bool>.NotFound($"Request with Id {id} not found");

            if (!IsValidFields(request))
                return Result<bool>.BadRequest("One or more fields are not valid");


            var success = _repositoryManager.Requests.Update(id, request);
            if (success==null)
                return Result<bool>.Failure("Failed to update Request");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        public Result<bool> DeleteRequest(int id)
        {
            var existingRequest = _repositoryManager.Requests.GetById(id);
            if (existingRequest == null)
                return Result<bool>.NotFound($"Request with Id {id} not found");

            var success = _repositoryManager.Requests.Delete(id);
            if (!success)
                return Result<bool>.Failure("Failed to delete Request");
            _repositoryManager.Save();
            return Result<bool>.Success(true);
        }

        private bool IsRequiredFields(Request request)
        {
            if (request == null) return false;
            if (request.HelpKind == null) return false;
            return true;
        }
        private bool IsValidFields(Request request)
        {
            if (_repositoryManager.Mothers.GetById(request.UserId) == null) return false;
            return true;
        }
    }
}
