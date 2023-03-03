using Application.Features.Usuario.GestionUsuario;
using Application.Features.Usuario.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Softtek_API.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("GestionUsuario")]
        public async Task<ActionResult> GestionAlmacen([FromBody] GestionUsuarioCommand usuario)
        {
            var response = await mediator.Send(usuario);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand login)
        {
            var response = await mediator.Send(login);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
