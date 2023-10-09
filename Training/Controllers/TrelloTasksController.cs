using AutoMapper;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Dtos;
using Training.MediatR.Commands;
using Training.MediatR.Queries;
using Training.Services;

namespace Training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrelloTasksController : ControllerBase
    {
        private readonly IMediator MyMediator;
        private readonly ITrelloTaskJobTestService TrelloTaskJobTestService;
        private readonly IBackgroundJobClient BackgroundJobClient;
        private readonly IRecurringJobManager RecurringJobManager;
    

        public TrelloTasksController(IMediator mediator, ITrelloTaskJobTestService trelloTaskTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager  )
        {
            MyMediator = mediator;
            TrelloTaskJobTestService = trelloTaskTestService;
            BackgroundJobClient = backgroundJobClient;
            RecurringJobManager = recurringJobManager;
          
        }


        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
           var tasks = await MyMediator.Send(new GetTasksQuery());
           return Ok(tasks);
        }

        [HttpGet("{id:Guid}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await MyMediator.Send(new GetTaskByIdQuery(id));
            return Ok(task);
        }

        [HttpPost]

        public async Task<IActionResult> AddTask(CreateTrelloTaskDto task)
        {
            var TaskToReturn = await MyMediator.Send(new AddTaskCommand(task));
            return CreatedAtRoute("GetTaskById", new {id = TaskToReturn.TaskId}, TaskToReturn);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTrelloTaskDto task)
        {
            var TaskToReturn = await MyMediator.Send(new UpdateTaskCommand(task));
            return Ok(TaskToReturn);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await MyMediator.Send(new DeleteTaskCommand(id));
            return Ok(task);
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
