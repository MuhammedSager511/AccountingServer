using AccountingServer.Domain.Dtos;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Invoices.CreateInvoice;
public sealed record CreateInvoiceCommand(
    int TypeValue,
    DateOnly Date,
    string InvoiceNumber,
    Guid CustomerId,
    List<InvoiceDetailDto> Details
) : IRequest<Result<string>>;
