using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace AccountingServer.Application.Features.Banks.DeleteBankById;
public sealed record DeleteBankByIdCommand(
    Guid Id): IRequest<Result<string>>;
