using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Banks.GetAllBanks;
public sealed record GetAllBanksQuery(): IRequest<Result<List<Bank>>>;
