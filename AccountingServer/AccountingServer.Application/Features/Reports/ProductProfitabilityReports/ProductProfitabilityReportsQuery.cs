using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Reports.ProductProfitabilityReports;
public sealed record ProductProfitabilityReportsQuery() : IRequest<Result<List<ProductProfitabilityReportsQueryResponse>>>;
