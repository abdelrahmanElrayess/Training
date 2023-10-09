using MediatR;
using Training.Data;
using Training.MediatR.Queries.CoulmnQuery;
using Training.Models;

namespace Training.MediatR.Handlers.CoulmnHandelers
{
    public class GetCoulmnById : IRequestHandler<GetCoulmnByIdQuery, TrelloColumn>
    {
        private readonly TrelloContext MyContext;

        public GetCoulmnById(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloColumn> Handle(GetCoulmnByIdQuery query, CancellationToken cancellationToken)
        {
            var column = await MyContext.Columns.FindAsync(query.CoulmnId, cancellationToken);

            if (column == null)
            {
                throw new Exception("Column not found");
            }

            return column;
        }

    }
}
