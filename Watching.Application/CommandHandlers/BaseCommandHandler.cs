using Watching.Application.Commands;
using Watching.Application.Interfaces;

namespace Watching.Application.CommandHandlers
{
    public abstract class BaseCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : BaseCommand<TResult>
    {
        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
