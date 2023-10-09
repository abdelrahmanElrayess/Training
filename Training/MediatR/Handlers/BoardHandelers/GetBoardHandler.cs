using MediatR;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.MediatR.Queries;
using Training.MediatR.Queries.BoardQuery;
using Training.Models;

namespace Training.MediatR.Handlers.BoardHandelers
{
    public class GetBoardHandler : IRequestHandler<GetBoardQuery, IEnumerable<TrelloBoard>>
    {
        private readonly TrelloContext MyContext;

        public GetBoardHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<IEnumerable<TrelloBoard>> Handle(
            GetBoardQuery query,
            CancellationToken cancellationToken
        )
        {
            return await MyContext.Boards.ToListAsync(cancellationToken);
        }
    }
}
