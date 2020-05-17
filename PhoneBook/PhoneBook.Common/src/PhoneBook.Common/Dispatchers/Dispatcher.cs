using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync(query);

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
            => await _commandDispatcher.SendAsync(command);
    }
}
