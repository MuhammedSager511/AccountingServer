using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.GetAllCompanies;
public sealed record GetAllCompaniesQuery() : IRequest<Result<List<Company>>>;
