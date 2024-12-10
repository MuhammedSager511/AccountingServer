using AccountingServer.Application.Features.Users.CreateUser;
using AccountingServer.Application.Features.Users.UpdateUser;
using AccountingServer.Domain.Entities;
using AutoMapper;

namespace AccountingServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();
        }
    }
}
