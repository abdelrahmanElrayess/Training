using MediatR;
using Training.Models;

namespace Training.MediatR.Queries
{
    public record GetTaskByIdQuery(Guid TaskId) : IRequest<TrelloTask>
    {
    }
}
