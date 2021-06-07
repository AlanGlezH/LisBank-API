using AutoMapper;
using LisBank.Core.DTOs;
using LisBank.Core.Entities;

namespace LisBank.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ReverseMap();

            CreateMap<DebitAccount, DebitAccountDTO>()
                .ForMember(src => src.Account, opt => opt.MapFrom(dest => dest.IdAccountNavigation))
                .ReverseMap();

            CreateMap<CreditAccount, CreditAccountDTO>()
                .ForMember(src => src.Account, opt => opt.MapFrom(dest => dest.IdAccountNavigation))
                .ReverseMap();

            CreateMap<Client, ClientDTO>()
                .ReverseMap();

            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();

            CreateMap<Role, RoleDTO>()
                .ReverseMap();
       
        }
    }
}
