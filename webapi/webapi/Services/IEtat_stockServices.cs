using Microsoft.EntityFrameworkCore.Update.Internal;
using webapi.Helper;
using webapi.Repos.Models;

namespace webapi.Services
{
    public interface IEtat_stockServices
    {
       Task<List<EtatStock>> GetAll_EtatStock();
       Task<APIResponse> UpdateStock(EtatStock etatstock );

    }
}
