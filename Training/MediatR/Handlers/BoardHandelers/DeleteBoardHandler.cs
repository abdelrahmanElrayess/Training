using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.BoardHandelers
{
    public class DeleteBoardHandler : IRequestHandler<DeleteBoardCommand, TrelloBoard>
    {
        private readonly TrelloContext MyContext;

        public DeleteBoardHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloBoard> Handle(DeleteBoardCommand command, CancellationToken cancellationToken)
        {
            var board = await MyContext.Boards.FindAsync(command.BoardId, cancellationToken);

            if (board == null)
            {
                throw new Exception("Board not found");
            }

            MyContext.Boards.Remove(board);
            await MyContext.SaveChangesAsync(cancellationToken);

            return board;
        }

    
    }
}
