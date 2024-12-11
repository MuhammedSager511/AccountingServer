using AccountingServer.WebAPI.Abstractions;
using FluentEmail.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class TestController : ApiController
    {
        private readonly IFluentEmail fluentEmail;

        public TestController(IMediator mediator,IFluentEmail fluentEmail) : base(mediator)
        {
            this.fluentEmail = fluentEmail;
        }

        [HttpGet]
        public async Task<IActionResult> SendTestEmail()
        {
            await fluentEmail
                .To("muhammed@gmail.com")
                .Subject("Test Mail")
                .Body("<h1>Email sending test</h1>", true)
                .SendAsync();
            return NoContent();
        }
    }
}
