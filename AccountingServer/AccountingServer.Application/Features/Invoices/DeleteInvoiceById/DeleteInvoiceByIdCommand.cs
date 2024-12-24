using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Invoices.DeleteInvoiceById;
public sealed record DeleteInvoiceByIdCommand(
    Guid Id) : IRequest<Result<string>>;
