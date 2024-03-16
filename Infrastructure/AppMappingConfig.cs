using AutoMapper;
using ggsport.Authentication.Model.Dto;
using ggsport.Authentication.Model.Entity;
using ggsport.Domain.Client;
using ggsport.Domain.Schedule.Model.Dto;
using ggsport.Domain.Schedule.Model.Entity;
using ggsport.Domain.Trainer;
using System;

namespace ggsport.Infrastructure
{
    public class AppMappingConfig : Profile
    {
        public AppMappingConfig()
        {
            CreateMap<LoginModel, UserModel>();

            CreateMap<RegisterModel, UserModel>();

            CreateMap<ScheduleModel, ScheduleRead>();

            CreateMap<ScheduleCreate, ScheduleModel>()
                .ForMember(dest => dest.Trainers, opt => opt.Ignore())
                .ForMember(dest => dest.Clients, opt => opt.Ignore())
                .ForMember(dest => dest.ScheduleTrainers, opt => opt.MapFrom(src => src.Trainers.Select(t => new ScheduleTrainer { TrainerId = t })))
                .ForMember(dest => dest.ScheduleClients, opt => opt.MapFrom(src => src.Trainers.Select(c => new ScheduleClient { ClientId = c })));

        }
    }

}
