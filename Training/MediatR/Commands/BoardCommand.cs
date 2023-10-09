using MediatR;
using Training.Dtos.BoardDtos;
using Training.Models;

namespace Training.MediatR.Commands
{
    public record AddBoardCommand(CreateBoardDto Board) : IRequest<TrelloBoard>;

    public record UpdateBoardCommand(UpdateBoardDto Board) : IRequest<TrelloBoard>;

    public record DeleteBoardCommand(Guid BoardId) : IRequest<TrelloBoard>;
}
