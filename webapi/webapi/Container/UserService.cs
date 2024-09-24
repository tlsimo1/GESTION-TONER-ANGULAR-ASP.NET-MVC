using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Helper;

using webapi.Repos.Models;
using webapi.Services;

namespace webapi.Container
{
    public class UserService : IUserServices
    {
        private readonly GestionTonerContext dbContext;

        private readonly ILogger<UserService> logger;
        public UserService(GestionTonerContext dbContext, ILogger<UserService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<APIResponse> CreateUser(User user)
        {
            APIResponse response = new APIResponse();
            try
            {
                this.logger.LogInformation("Create Begins");
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = user.ReferenceToner;
            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.Result = ex.Message;
                this.logger.LogError(ex.Message,ex);
            }
            return response;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByReference(int Id)
        {
            APIResponse response = new APIResponse();
            var user = await dbContext.Users.FindAsync(Id);
            try
            {
                if (user != null)
                {
                    response.ResponseCode = 200;
                    response.Result = Convert.ToString(Id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return user;
        }

        public async Task<APIResponse> RemoveUser(int Id)
        {
            APIResponse response = new APIResponse();
            try
            {
                var user= await dbContext.Users.FindAsync(Id);
                if(user!=null)
                {
                    dbContext.Users.Remove(user);
                    await dbContext.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result =Convert.ToString(Id);
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Result = "data not found";
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.Result = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> UpdateUser(User user, int Id)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _user = await dbContext.Users.FindAsync(Id);
                if (_user != null)
                {
                    _user.Utilisateur = user.Utilisateur;
                    _user.ReferenceToner= user.ReferenceToner;
                    _user.Departement = user.Departement;
                    _user.Email= user.Email;
                    _user.Phone = user.Phone;
                    _user.Password = user.Password;
                    _user.Role = user.Role;
                    await dbContext.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = Convert.ToString(Id);
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Result = "data not found";
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.Result = ex.Message;
            }
            return response;
        }
    }
}
