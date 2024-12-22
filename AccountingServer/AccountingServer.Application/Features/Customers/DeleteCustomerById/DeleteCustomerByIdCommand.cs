using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Customers.DeleteCustomerById;
public sealed record DeleteCustomerByIdCommand(
    Guid Id): IRequest<Result<string>>;
