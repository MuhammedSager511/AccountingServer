using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Customers.GetAllCustomers;

internal sealed class GetAllCustomersQueryHandler(
    ICustomerRepository customerRepository,
    ICacheService cacheService) : IRequestHandler<GetAllCustomersQuery, Result<List<Customer>>>
{
    public async Task<Result<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        List<Customer>? customers = cacheService.Get<List<Customer>>("customers");

        if(customers is null)
        {
            customers = 
                await customerRepository
                .GetAll()
                .OrderBy(p => p.Name)
                .ToListAsync(cancellationToken);

            cacheService.Set("customers", customers);
        }

        return customers;
    }
}
