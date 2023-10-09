using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.CoulmnHandelers
{
    public class DeleteCoulmn : IRequestHandler<DeleteCoulmnCommand, TrelloColumn>
    {
        private readonly TrelloContext MyContext;

        public DeleteCoulmn(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloColumn> Handle(DeleteCoulmnCommand command, CancellationToken cancellationToken)
        {
            var column = await MyContext.Columns.FindAsync(command.CoulmnId, cancellationToken);


            if (column == null)
            {
                  throw new Exception("Column not found");
            }

            MyContext.Columns.Remove(column);
            await MyContext.SaveChangesAsync(cancellationToken);

            return column;
        }

    }
}
