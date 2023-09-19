using MediatR;
using Watching.Application.Commands;

namespace Watching.Application.Interfaces
{
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : BaseCommand<TResponse>
    {
    }
}
