using Azure;
using Microsoft.EntityFrameworkCore;
using webapi.Helper;

using webapi.Repos.Models;
using webapi.Services;


namespace webapi.Container
{
    public class BaseTonerService : IbaseTonerService
    {
        private readonly GestionTonerContext dbcontext;
        public BaseTonerService(GestionTonerContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<APIResponse> CreateToner(BaseToner baseToner)
        {
            APIResponse response = new APIResponse();
            try
            {
                await dbcontext.BaseToners.AddAsync(baseToner);
                await dbcontext.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = baseToner.Reference;
            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.Result = ex.Message;
            }
            return response;
        }

        public async Task<List<BaseToner>> GetAllToner()
        {
            return await dbcontext.BaseToners.ToListAsync();
        }

        public async Task<APIResponse> RemoveToner(string  Reference)
        {
            APIResponse response = new APIResponse();
            try
            {
                var Toner = await dbcontext.BaseToners.Where(x=>x.Reference== Reference).FirstOrDefaultAsync();
                if (Toner != null)
                {
                    dbcontext.BaseToners.Remove(Toner);
                    await dbcontext.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = Convert.ToString(Reference);
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

        public async Task<APIResponse> UpdateToner(BaseToner baseToner)
        {
            APIResponse apiResponse = new APIResponse();
            var _baseToner = await (from toner in dbcontext.BaseToners
                                   where toner.Reference == baseToner.Reference
                                   select toner).FirstOrDefaultAsync();
            try
            {
                if(_baseToner!=null)
                {
                    _baseToner.Reference = baseToner.Reference;
                    _baseToner.Description = baseToner.Description;
                    await dbcontext.SaveChangesAsync();
                    apiResponse.ResponseCode = 200;
                    apiResponse.Result = Convert.ToString(_baseToner.Reference);
                }
                else
                {
                    apiResponse.ResponseCode = 404;
                    apiResponse.Result = "data not found";
                }

            }
            catch (Exception ex)
            {
                apiResponse.ResponseCode = 400;
                apiResponse.Result = ex.Message;
            }
            return apiResponse;
        }
    }
}
