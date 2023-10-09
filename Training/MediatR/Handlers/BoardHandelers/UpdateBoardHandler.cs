using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.BoardHandelers
{
    public class UpdateBoardHandler : IRequestHandler<UpdateBoardCommand, TrelloBoard>
    {
        private readonly TrelloContext MyContext;

        public UpdateBoardHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloBoard> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await MyContext.Boards.FindAsync(request.Board.BoardId, cancellationToken);
      
            if (board == null)
            {
                throw new Exception("Board not found");
            }

            if (request.Board.Title is { })
            {
                board.Title = request.Board.Title;
            }

            if (request.Board.Columns is  { } coulmn && coulmn.Apply)
            {
                board.Columns = coulmn.WrappedValue;
            }
           
            await MyContext.SaveChangesAsync(cancellationToken);

            return board;
            
        }

    }
}
