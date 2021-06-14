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

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(src => src.Origin, opt => opt.MapFrom(dest => dest.IdOriginNavigation))
                .ReverseMap();

            CreateMap<Origin, OriginDTO>()
                .ReverseMap();

            CreateMap<Payment, PaymentDTO>()
                .ReverseMap();

            CreateMap<Account, InsertDebitAccountDTO>()
                .ReverseMap();

            CreateMap<AccountDTO, InsertDebitAccountDTO>()
                .ReverseMap();

            CreateMap<DebitAccount, InsertDebitAccountDTO>()
                .ReverseMap();

            CreateMap<DebitAccountDTO, InsertDebitAccountDTO>()
                .ReverseMap();

            CreateMap<Client, InsertDebitAccountDTO>()
                .ReverseMap();

            CreateMap<Client, InsertDebitAccountDTO> ()
                .ReverseMap();
       
        }
    }
}
