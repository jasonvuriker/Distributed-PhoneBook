using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Common.Handlers;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;
        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task SendAsync<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }
    }
}
