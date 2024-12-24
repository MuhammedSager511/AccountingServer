using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Reports.PurchaseReports;
public sealed record PurchaseReportsQuery(): IRequest<Result<object>>;
