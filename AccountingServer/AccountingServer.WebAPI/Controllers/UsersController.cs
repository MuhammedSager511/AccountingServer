using AccountingServer.Application.Features.Users.CreateUser;
using AccountingServer.Application.Features.Users.DeleteUserById;
using AccountingServer.Application.Features.Users.GetAllUsers;
using AccountingServer.Application.Features.Users.UpdateUser;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingServer.WebAPI.Controllers
{

    public sealed class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public  async Task<IActionResult> GetAll(GetAllUsersQuery request,CancellationToken cancellationToken)
        {
            var response=await _mediator.Send(request,cancellationToken);
            return StatusCode(response.StatusCode,response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
