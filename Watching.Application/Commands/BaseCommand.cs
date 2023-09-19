using MediatR;

namespace Watching.Application.Commands
{
    public abstract class BaseCommand<TResponse> : IRequest<TResponse>
    {
    }
}
