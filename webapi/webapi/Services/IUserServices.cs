using webapi.Helper;
using webapi.Repos.Models;

namespace webapi.Services
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByReference(int Id);
        Task<APIResponse> CreateUser(User user);
        Task<APIResponse> UpdateUser(User user, int Id);
        Task<APIResponse> RemoveUser(int Id);

    }
}
