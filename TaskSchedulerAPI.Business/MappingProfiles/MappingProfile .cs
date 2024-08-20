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
            // User Entity <-> User DTOs
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            // Task Entity <-> Task DTOs
            CreateMap<Task, TaskCreateDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}
