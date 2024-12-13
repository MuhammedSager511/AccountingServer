using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.SendConfirmEmail;

public sealed record SendConfirmEmailCommand(string email):IRequest<Result<string>>;

