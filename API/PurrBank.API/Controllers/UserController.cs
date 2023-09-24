using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurrBank.BusinessRules.Commands;
using PurrBank.BusinessRules.Commands.UserCommand;
using PurrBank.BusinessRules.Queries.UserQueries;
using PurrBank.Entities;

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
        public IActionResult CreateUser([FromBody] CreateUserCommand command, [FromServices] IMediator mediator)
            => Return(mediator.Send(command).Result);
        /// <summary>
        /// Get an User by id.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetById([FromQuery] int id, [FromServices] IMediator mediator)
            => Return(mediator.Send(new GetUserByIdQuery() { Id = id }).Result);
        /// <summary>
        /// Get an User by email.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetByEmail([FromQuery] string email, [FromServices] IMediator mediator)
            => Return(mediator.Send(new GetUserByFilterQuery() { Email = email }).Result);
        /// <summary>
        /// Update an User.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserCommand command, [FromServices] IMediator mediator)
            => Return(mediator.Send(command).Result);
        /// <summary>
        /// Delete an User.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CommandResult<User>), StatusCodes.Status200OK)]
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id, [FromServices] IMediator mediator)
            => Return(mediator.Send(new DeleteUserCommand() { Id = id }).Result);
        private IActionResult Return(dynamic result)
        {
            if (result.Message.Contains("Ok"))
            {
                return Ok(result);
            }
            else if (result.Message.Contains("BadRequest"))
            {
                return BadRequest(result);
            }
            else if (result.Message.Contains("NoContent"))
            {
                return StatusCode(StatusCodes.Status204NoContent, result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
