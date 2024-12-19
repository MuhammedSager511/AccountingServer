using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.CashRegisters.GetAllCashRegisters;
public sealed record GetAllCashRegistersQuery() : IRequest<Result<List<CashRegister>>>;
