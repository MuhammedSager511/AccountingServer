using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CustomerDetails.GetAllCustomerDetails;
public sealed record GetAllCustomerDetailsQuery(
    Guid CustomerId) : IRequest<Result<Customer>>;
