using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers
{
    public class DeleteTask : IRequestHandler<DeleteTaskCommand, TrelloTask>
    {
        private readonly TrelloContext MyContext;

        public DeleteTask(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloTask> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await MyContext.Tasks.FindAsync(command.TaskId, cancellationToken);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            MyContext.Tasks.Remove(task);
            await MyContext.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}
