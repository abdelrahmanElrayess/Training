using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Dtos;
using Training.Dtos.CoulmnDtos;
using Training.MediatR.Commands;
using Training.MediatR.Queries;
using Training.MediatR.Queries.CoulmnQuery;
using Training.Services;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrelloCoulmnsController : ControllerBase
    {

        private readonly IMediator MyMediator;
        private readonly ITrelloTaskJobTestService TrelloTaskJobTestService;
        private readonly IBackgroundJobClient BackgroundJobClient;
        private readonly IRecurringJobManager RecurringJobManager;
        public TrelloCoulmnsController(IMediator mediator, ITrelloTaskJobTestService trelloTaskTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            MyMediator = mediator;
            TrelloTaskJobTestService = trelloTaskTestService;
            BackgroundJobClient = backgroundJobClient;
            RecurringJobManager = recurringJobManager;

        }





        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var coulmn = await MyMediator.Send(new GetCoulmnQuery());
            return Ok(coulmn);
        }


        [HttpGet("{id:Guid}", Name = "GetCoulmnById")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var coulmn = await MyMediator.Send(new GetCoulmnByIdQuery(id));
            return Ok(coulmn);
        }



        [HttpPost]

        public async Task<IActionResult> AddCoulmn(CreateCoulmnDto Coulmn)
        {
            var CoulmnToReturn = await MyMediator.Send(new AddCoulmnCommand(Coulmn));
            return CreatedAtRoute("GetCoulmnById", new { id = CoulmnToReturn.ColumnId }, CoulmnToReturn);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCoulmn(UpdateCoulmnDto Coulmn)
        {
            var CoulmnToReturn = await MyMediator.Send(new UpdateCoulmnCommand(Coulmn));
            return Ok(CoulmnToReturn);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoulmn(Guid id)
        {
            var coulmn = await MyMediator.Send(new DeleteCoulmnCommand(id));
            return Ok(coulmn);
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
