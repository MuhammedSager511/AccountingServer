using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Customers.GetAllCustomers;
public sealed record GetAllCustomersQuery() : IRequest<Result<List<Customer>>>;
