using Application.Features.Empresa.Command.GestionEmpresa;
using Data;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Softtek_API.Controllers
{
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;

        public EmpresaController(SoftteckContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetEmpresas")]
        public async Task<IActionResult> GetEmpresas()
        {
            return Ok(context.Empresas.ToList());
        }

        [HttpPost]
        [Route("GestionEmpresa")]
        public async Task<ActionResult> GestionEmpresa([FromBody] GestionEmpresaCommand empresa)
        {
            var response = await mediator.Send(empresa);
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
