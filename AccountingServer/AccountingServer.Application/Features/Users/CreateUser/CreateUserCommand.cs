using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace AccountingServer.Application.Features.Users.CreateUser;

public sealed record class CreateUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password
    ):IRequest<Result<string>>;
