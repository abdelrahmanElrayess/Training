using MediatR;
using Training.Models;

namespace Training.MediatR.Queries
{
    public record GetTasksQuery() : IRequest<IEnumerable<TrelloTask>>;

}
