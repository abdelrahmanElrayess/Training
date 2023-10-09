using MediatR;
using Training.Data;
using Training.MediatR.Commands;
using Training.Models;

namespace Training.MediatR.Handlers
{
    public class UpdateTaskHanlder : IRequestHandler<UpdateTaskCommand, TrelloTask>
    {
        private readonly TrelloContext MyContext;
    
        public UpdateTaskHanlder(TrelloContext context)
        {
            MyContext = context;
        }

        public async Task<TrelloTask> Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await MyContext.Tasks.FindAsync(command.Task.TaskId, cancellationToken);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            
            if (command.Task.ColumnId is { } columnId)
            {
                task.ColumnId = columnId;
            }
            if (command.Task.Title is { } title)
            {
                task.Title = title;
            }
            if (command.Task.Description is { } descriptionWrapper && descriptionWrapper.Apply) 
            {
                task.Description = descriptionWrapper.WrappedValue;
            }
            if (command.Task.DueDate is { } dueDate && dueDate.Apply)
            {
                task.DueDate = dueDate.WrappedValue;
            }
            if (command.Task.AssignedTo is { } assignedToWrapper)
            {
                task.AssignedTo = assignedToWrapper;
            }

            if (command.Task.Status is { } statusWrapper)
            {
                task.Status = statusWrapper;
            }

            if (command.Task.Priority is { } priorityWrapper)
            {
                task.Priority = priorityWrapper;
            }







            task.UpdatedAt = DateTime.Now;
            
            await MyContext.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}
