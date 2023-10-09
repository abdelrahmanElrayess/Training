using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.CoulmnHandelers
{
    public class UpdateCoulmnHandler : IRequestHandler<UpdateCoulmnCommand, TrelloColumn>
    {
        private readonly TrelloContext MyContext;

        public UpdateCoulmnHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloColumn> Handle(UpdateCoulmnCommand command, CancellationToken cancellationToken)
        {
            var column = await MyContext.Columns.FindAsync(command.Coulmn.ColumnId, cancellationToken);


            if (column == null)
            {
                throw new Exception("Column not found");
            }

            if (command.Coulmn.Title is { })
            {
                column.Title = command.Coulmn.Title;
            }

 
         

            await MyContext.SaveChangesAsync(cancellationToken);

            return column;
        }

    }
}
