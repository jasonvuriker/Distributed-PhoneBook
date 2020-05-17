using System;
using System.Linq;

namespace PhoneBook.Common.Types
{
    public static class Extensions
    {
        public static PagedResult<T> Paginate<T>(this IQueryable<T> query, int skip, int take) where T : class
            => PagedResult<T>(query, skip, take);

        public static PagedResult<T> PagedResult<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.Total = query.Count();
            var pageCount = (double)result.Total / pageSize;
            var skip = page * pageSize;

            result.Data = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }
    }
}