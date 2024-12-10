using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace AccountingServer.Application.Features.Users.DeleteUserById;

public sealed record class DeleteUserByIdCommand(Guid Id):IRequest<Result<string>>;
