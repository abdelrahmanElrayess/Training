using MediatR;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.MediatR.Queries;
using Training.Models;

namespace Training.MediatR.Handlers
{
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, IEnumerable<TrelloTask>>
    {
        private readonly TrelloContext MyContext;

        public GetTasksHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<IEnumerable<TrelloTask>> Handle(GetTasksQuery query, CancellationToken cancellationToken)
        {
            return await MyContext.Tasks.ToListAsync(cancellationToken);
        }
    }
}
