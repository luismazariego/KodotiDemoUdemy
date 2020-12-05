using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Common.Collection;

namespace Services.Common.Paging
{
    public static class PagingExtensinon
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            int originalPages = page;
            page--;

            if (page > 0)
            {
                page *= take;
            }

            DataCollection<T> result = new()
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPages
            };

            if(result.Total>0)
            {
                result.Pages = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        } 
    }
}
