using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Common.Handlers;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;
        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _provider.GetService(handlerType);
            var typd = handler.GetType();
            return await handler.HandleAsync((dynamic)query);
        }
    }
}
