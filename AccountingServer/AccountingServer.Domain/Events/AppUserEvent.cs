using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingServer.Domain.Events;

public sealed class AppUserEvent:INotification
{
    public AppUserEvent(Guid userId)
    {
        UserId = userId;
    }
    public Guid UserId { get;private set; }
}

