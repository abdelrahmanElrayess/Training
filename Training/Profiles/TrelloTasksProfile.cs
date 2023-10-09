using AutoMapper;
using Training.Dtos;
using Training.Models;

namespace Training.Profiles
{
    public class TrelloTasksProfile : Profile
    {
        public TrelloTasksProfile()
        {
            CreateMap<TrelloTask, TrelloTaskDto>();
            CreateMap<CreateTrelloTaskDto, TrelloTask>();
            CreateMap<UpdateTrelloTaskDto, TrelloTask>();
        }
    }
}
