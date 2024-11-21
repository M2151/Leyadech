using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using System.Collections.Generic;

namespace Leyadech.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMotherRepository _motherRepository;
        public RequestService(IRequestRepository requestRepository, IMotherRepository motherRepository)
        {
            _requestRepository = requestRepository;
            _motherRepository = motherRepository;
        }

        public Result<IEnumerable<Request>> GetAllRequests()
        {
            var requests = _requestRepository.GetList();
            return Result<IEnumerable<Request>>.Success(requests);
        }

        public Result<Request> GetRequestById(int id)
        {
            var request = _requestRepository.GetById(id);
            if (request == null)
                return Result<Request>.NotFound($"Request with Id {id} not found");

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

            var success = _requestRepository.Add(request);
            if (!success)
                return Result<bool>.Failure("Failed to add Request");

            return Result<bool>.Success(true);
        }

        public Result<bool> UpdateRequest(int id, Request request)
        {
            if (request == null)
                return Result<bool>.BadRequest("Cannot update null Request");

            var existingRequest = _requestRepository.GetById(id);
            if (existingRequest == null)
                return Result<bool>.NotFound($"Request with Id {id} not found");

            if (!IsValidFields(request))
                return Result<bool>.BadRequest("One or more fields are not valid");
            if (!IsRequiredFields(request))
                return Result<bool>.BadRequest("One or more required fields are missing");

            var success = _requestRepository.Update(id, request);
            if (!success)
                return Result<bool>.Failure("Failed to update Request");

            return Result<bool>.Success(true);
        }

        public Result<bool> DeleteRequest(int id)
        {
            var existingRequest = _requestRepository.GetById(id);
            if (existingRequest == null)
                return Result<bool>.NotFound($"Request with Id {id} not found");

            var success = _requestRepository.Delete(id);
            if (!success)
                return Result<bool>.Failure("Failed to delete Request");

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
            if (_motherRepository.GetById(request.UserId) == null) return false;
            return true;
        }
    }
}
