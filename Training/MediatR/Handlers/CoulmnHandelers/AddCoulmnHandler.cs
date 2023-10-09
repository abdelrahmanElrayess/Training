using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers.CoulmnHandelers
{
    public class AddCoulmnHandler : IRequestHandler<AddCoulmnCommand, TrelloColumn>
    {
        private readonly TrelloContext MyContext;

        public AddCoulmnHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloColumn> Handle(AddCoulmnCommand command, CancellationToken cancellationToken)
        {
            var column = new TrelloColumn
            {
                ColumnId = new Guid(),
                Title = command.Coulmn.Title,
                BoardId = new Guid()
            };


            await MyContext.Columns.AddAsync(column, cancellationToken);
            await MyContext.SaveChangesAsync(cancellationToken);

            return column;
        }
    }
}
