using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand , TrelloTask>
    {
        private readonly TrelloContext MyContext;

        public AddTaskHandler(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task <TrelloTask> Handle(AddTaskCommand command, CancellationToken cancellationToken)
        {
            var task = new TrelloTask
            {
                TaskId = new Guid(),
                ColumnId = command.Task.ColumnId,
                Title = command.Task.Title,
                Description = command.Task.Description,
                DueDate = command.Task.DueDate,
                AssignedTo = command.Task.AssignedTo,
                Status = command.Task.Status,
                Priority = command.Task.Priority
                
            };



            await MyContext.Tasks.AddAsync(task, cancellationToken);
            await MyContext.SaveChangesAsync(cancellationToken);

            return task;
        }

    }
}
