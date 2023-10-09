using MediatR;
using Training.Data;
using Training.MediatR.Queries;
using Training.Models;

namespace Training.MediatR.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TrelloTask>
    {
        private readonly TrelloContext MyContext;

        public GetTaskByIdHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloTask> Handle(GetTaskByIdQuery query, CancellationToken cancellationToken)
        {
            
            var task = await MyContext.Tasks.FindAsync(query.TaskId, cancellationToken);

            return task;
        }

    }
}
