using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Invoices.GetAllInvoices;
public sealed record GetAllInvoicesQuery() : IRequest<Result<List<Invoice>>>;
