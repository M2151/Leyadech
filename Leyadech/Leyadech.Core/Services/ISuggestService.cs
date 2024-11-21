using Leyadech.Core.Entities;
using System.Collections.Generic;

namespace Leyadech.Core.Services
{
    public interface ISuggestService
    {
        Result<IEnumerable<Suggest>> GetAllSuggests();
        Result<Suggest> GetSuggestById(int id);
        Result<bool> AddSuggest(Suggest suggest);
        Result<bool> UpdateSuggest(int id, Suggest suggest);
        Result<bool> DeleteSuggest(int id);
    }
}
