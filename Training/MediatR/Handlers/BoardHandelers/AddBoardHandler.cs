using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.BoardHandelers
{
    public class AddBoardHandler : IRequestHandler<AddBoardCommand, TrelloBoard>
    {
        private readonly TrelloContext MyContext;

        public AddBoardHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloBoard> Handle(
            AddBoardCommand command,
            CancellationToken cancellationToken
        )
        {
            var board = new TrelloBoard { BoardId = new Guid(), Title = command.Board.Title, };

            await MyContext.Boards.AddAsync(board, cancellationToken);
            await MyContext.SaveChangesAsync(cancellationToken);

            return board;
        }
    }
}
