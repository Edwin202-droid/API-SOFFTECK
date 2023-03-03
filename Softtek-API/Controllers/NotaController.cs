using Application.Features.Nota.Command.CreateNota;
using Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Softtek_API.Controllers
{
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;

        public NotaController(SoftteckContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateNota")]
        public async Task<ActionResult> CreateNota([FromBody] CreateNotaCommand nota)
        {
            var response = await mediator.Send(nota);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Mensaje);
            }
        }
    }
}
