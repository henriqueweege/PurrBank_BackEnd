using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurrBank.BusinessRules.Commands;
using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Entities;
using PurrBank.Tools;

namespace PurrBank.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
#pragma warning disable 1591
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a User.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, [FromServices] IMediator mediator)
            => await RestTools<User>.Return(await mediator.Send(command));
        /// <summary>
        /// Get an User by id.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id, [FromServices] IMediator mediator)
            => await RestTools<User>.Return(await mediator.Send(new GetUserByIdQuery() { Id = id }));
        /// <summary>
        /// Get an User by email.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetByEmail([FromQuery] string email, [FromServices] IMediator mediator)
            => await RestTools<User>.Return(await mediator.Send(new GetUserByFilterQuery() { Email = email }));
        /// <summary>
        /// Update an User.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command, [FromServices] IMediator mediator)
            => await RestTools<User>.Return(await mediator.Send(command));
        /// <summary>
        /// Delete an User.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromServices] IMediator mediator)
            => await RestTools<User>.Return(await mediator.Send(new DeleteUserCommand() { Id = id }));

    }
}
