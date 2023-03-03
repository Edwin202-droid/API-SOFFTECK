using Application.Features.Nota.Command.CreateNota;
using Application.Features.Nota.Query.GetNotas;
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

        [HttpGet]
        [Route("GetNotas")]
        public async Task<ActionResult<List<NotasVm>>> GetNotas()
        {
            var response = await mediator.Send(new GetNotaQuery { });
            return Ok(response);
        }
    }
}
