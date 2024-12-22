using AccountingServer.Application.Features.Banks.CreateBank;
using AccountingServer.Application.Features.Banks.UpdateBank;
using AccountingServer.Application.Features.CashRegisters.CreateCashRegister;
using AccountingServer.Application.Features.CashRegisters.UpdateCashRegister;
using AccountingServer.Application.Features.Companies.CreateCompany;
using AccountingServer.Application.Features.Companies.UpdateCompany;
using AccountingServer.Application.Features.Customers.CreateCustomer;
using AccountingServer.Application.Features.Customers.UpdateCustomer;
using AccountingServer.Application.Features.Users.CreateUser;
using AccountingServer.Application.Features.Users.UpdateUser;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Enums;
using AutoMapper;

namespace AccountingServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();

            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();

            CreateMap<CreateCashRegisterCommand, CashRegister>().ForMember(member => member.CurrencyType, options =>
            {
                options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue));
            });
            CreateMap<UpdateCashRegisterCommand, CashRegister>().ForMember(member => member.CurrencyType, options =>
            {
                options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue));
            });



            CreateMap<CreateBankCommand, Bank>().ForMember(member => member.CurrencyType, options =>
            {
                options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue));
            });
            CreateMap<UpdateBankCommand, Bank>().ForMember(member => member.CurrencyType, options =>
            {
                options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue));
            });



            CreateMap<CreateCustomerCommand, Customer>().ForMember(member => member.Type, options =>
            {
                options.MapFrom(map => CustomerTypeEnum.FromValue(map.TypeValue));
            });
            CreateMap<UpdateCustomerCommand, Customer>().ForMember(member => member.Type, options =>
            {
                options.MapFrom(map => CustomerTypeEnum.FromValue(map.TypeValue));
            });

        }
    }
}
