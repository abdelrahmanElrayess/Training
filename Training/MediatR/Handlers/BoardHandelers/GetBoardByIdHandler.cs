using MediatR;
using Training.Data;
using Training.MediatR.Queries;
using Training.MediatR.Queries.BoardQuery;
using Training.Models;

namespace Training.MediatR.Handlers.BoardHandelers
{
    public class GetBoardByIdHandler : IRequestHandler<GetBoardByIdQuery, TrelloBoard>
    {
        private readonly TrelloContext MyContext;

        public GetBoardByIdHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloBoard> Handle(
            GetBoardByIdQuery query,
            CancellationToken cancellationToken
        )
        {
            var Board = await MyContext.Boards.FindAsync(query.BoardId, cancellationToken);

            if (Board == null)
            {
                throw new Exception("Board not found");
            }

            return Board;
        }
    }
}
