using webapi.Helper;
using webapi.Repos.Models;

namespace webapi.Services
{
    public interface IbaseTonerService
    {
        Task<List<BaseToner>> GetAllToner();
        Task<APIResponse> CreateToner(BaseToner baseToner);
        Task<APIResponse> UpdateToner(BaseToner baseToner);
        Task<APIResponse> RemoveToner(string Reference);
    }
}
