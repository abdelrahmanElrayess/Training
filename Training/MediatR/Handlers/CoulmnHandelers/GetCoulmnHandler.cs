using MediatR;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.MediatR.Queries;
using Training.MediatR.Queries.CoulmnQuery;
using Training.Models;

namespace Training.MediatR.Handlers.CoulmnHandelers
{
    public class GetCoulmnHandler : IRequestHandler<GetCoulmnQuery, IEnumerable<TrelloColumn>>
    {
        private readonly TrelloContext MyContext;

        public GetCoulmnHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<IEnumerable<TrelloColumn>> Handle(GetCoulmnQuery query, CancellationToken cancellationToken)
        {
            return await MyContext.Columns.ToListAsync(cancellationToken);
        }


    }
    
    
}
