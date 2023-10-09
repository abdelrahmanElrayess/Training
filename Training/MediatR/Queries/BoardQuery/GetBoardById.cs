using MediatR;
using Training.Models;

namespace Training.MediatR.Queries.BoardQuery
{
    public record GetBoardByIdQuery(Guid BoardId) : IRequest<TrelloBoard>
    {
    }
}
