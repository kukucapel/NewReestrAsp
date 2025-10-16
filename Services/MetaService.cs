using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Models;

namespace NewReestrAsp.Services
{
    public class MetaService
    {
        public MetaService()
        {
            
        }
    
        public async Task<Meta> GenerateMetaAsync<T>(DbSet<T> dbSet, int page, int coutPerPage) where T : class
        {
            var totalCount = await dbSet.CountAsync();

            var meta = new Meta
            {
                Page = page,
                Limit = coutPerPage,
                Total = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / coutPerPage)
            };
            return meta;
        }
    }
}