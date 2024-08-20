using AutoMapper;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.Core.Entities;
using Task = TaskSchedulerAPI.Core.Entities.Task;

namespace TaskSchedulerAPI.Business.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            
            CreateMap<Task, TaskCreateDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}
