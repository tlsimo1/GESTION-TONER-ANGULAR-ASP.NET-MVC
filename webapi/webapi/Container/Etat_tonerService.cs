using Microsoft.EntityFrameworkCore;
using webapi.Helper;

using webapi.Repos.Models;
using webapi.Services;

namespace webapi.Container
{
    public class Etat_tonerService : IEtat_stockServices
    {
        private readonly GestionTonerContext dbContext;
        public Etat_tonerService(GestionTonerContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<EtatStock>> GetAll_EtatStock()
        {
            return await dbContext.EtatStocks.ToListAsync();
        }

        public async Task<APIResponse> UpdateStock(EtatStock etatStock)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _etatStock = await dbContext.EtatStocks.FirstOrDefaultAsync(s => s.ReferenceId == etatStock.ReferenceId);
                if (_etatStock != null)
                {
                    _etatStock.ReferenceId = etatStock.ReferenceId;
                    _etatStock.SommeEntree = etatStock.SommeEntree;
                    _etatStock.SommeSortie = etatStock.SommeSortie;
                    
                    await dbContext.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = Convert.ToString(etatStock.ReferenceId);
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
