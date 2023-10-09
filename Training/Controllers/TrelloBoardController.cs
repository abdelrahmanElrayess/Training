using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Dtos.BoardDtos;
using Training.MediatR.Commands;
using Training.MediatR.Queries.BoardQuery;
using Training.Services;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrelloBoardController : ControllerBase
    {

        private readonly IMediator MyMediator;
        private readonly ITrelloTaskJobTestService TrelloTaskJobTestService;
        private readonly IBackgroundJobClient BackgroundJobClient;
        private readonly IRecurringJobManager RecurringJobManager;
        public TrelloBoardController(IMediator mediator, ITrelloTaskJobTestService trelloTaskTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            MyMediator = mediator;
            TrelloTaskJobTestService = trelloTaskTestService;
            BackgroundJobClient = backgroundJobClient;
            RecurringJobManager = recurringJobManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var board = await MyMediator.Send(new GetBoardQuery());
            return Ok(board);
        }

        [HttpGet("{id:Guid}", Name = "GetBoardById")]

        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var board = await MyMediator.Send(new GetBoardByIdQuery(id));
            return Ok(board);
        }

        [HttpPost]

        public async Task<IActionResult> AddBoard(CreateBoardDto board)
        {
            var BoardToReturn = await MyMediator.Send(new AddBoardCommand(board));
            return CreatedAtRoute("GetBoardById", new { id = BoardToReturn.BoardId }, BoardToReturn);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBoard(UpdateBoardDto board)
        {
            var BoardToReturn = await MyMediator.Send(new UpdateBoardCommand(board));
            return Ok(BoardToReturn);
        }

        [HttpDelete("{id:Guid}")]

        public async Task<IActionResult> DeleteBoard(Guid id)
        {
            var BoardToReturn = await MyMediator.Send(new DeleteBoardCommand(id));
            return Ok(BoardToReturn);
        }








        // Hangfire

        [HttpGet("/FireAndForgetJob")]
        public ActionResult CreateFireAndForgetJob()
        {
            BackgroundJobClient.Enqueue(() => TrelloTaskJobTestService.FireAndForgetJob());
            return Ok();
        }


        [HttpGet("/DelayedJob")]
        public ActionResult CreateDelayedJob()
        {
            BackgroundJobClient.Schedule(() => TrelloTaskJobTestService.DelayedJob(), TimeSpan.FromSeconds(60));
            return Ok();
        }

        [HttpGet("/ReccuringJob")]
        public ActionResult CreateReccuringJob()
        {
            RecurringJobManager.AddOrUpdate("jobId", () => TrelloTaskJobTestService.ReccuringJob(), Cron.Minutely);
            return Ok();
        }


        [HttpGet("/ContinuationJob")]
        public ActionResult CreateContinuationJob()
        {
            var parentJobId = BackgroundJobClient.Enqueue(() => TrelloTaskJobTestService.FireAndForgetJob());
            BackgroundJobClient.ContinueJobWith(parentJobId, () => TrelloTaskJobTestService.ContinuationJob());

            return Ok();
        }


    }
}
