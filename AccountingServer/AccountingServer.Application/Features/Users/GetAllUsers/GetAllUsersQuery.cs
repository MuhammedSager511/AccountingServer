using AccountingServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace AccountingServer.Application.Features.Users.GetAllUsers;

public sealed record class GetAllUsersQuery:IRequest<Result< List<AppUser>>>;
