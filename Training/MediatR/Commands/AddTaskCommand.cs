using MediatR;
using Training.Dtos;
using Training.Models;

namespace Training.MediatR.Commands
{
    public record AddTaskCommand(CreateTrelloTaskDto Task) : IRequest<TrelloTask>;

    public record UpdateTaskCommand(UpdateTrelloTaskDto Task) : IRequest<TrelloTask>;

    public record DeleteTaskCommand(Guid TaskId) : IRequest<TrelloTask>;
}
