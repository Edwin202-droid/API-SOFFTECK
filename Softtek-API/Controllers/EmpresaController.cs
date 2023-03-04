using Application.Features.Empresa.Command.GestionEmpresa;
using Application.Features.Empresa.Query.GetEmpresaPaginado;
using Application.Features.Empresa.Query.GetEmpresas;
using Data;
using Domain.Entities;
using DTO;
using Helpers.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Softtek_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;
        private readonly UserManager<Usuario> userManager;

        public EmpresaController(SoftteckContext context, IMediator mediator, UserManager<Domain.Entities.Usuario> userManager)
        {
            this.context = context;
            this.mediator = mediator;
            this.userManager = userManager;
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

        [HttpPost("EmpresaPaginado")]
        public async Task<ActionResult<List<EmpresaPaginado>>> GetEmpresaPaginado([FromBody] FiltroPaginado filtro)
        {

            var page = new PagedRequest
            {
                PageNumber = filtro.NumeroPagina,
                PageSize = 10
            };

            var request = new GetEmpresaPaginadoQuery
            {
                Page = page
            };
            var response = await mediator.Send(request);

            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.paging));
            return Ok(response.records);
        }

        [HttpGet("GetEmpresas")]
        public async Task<ActionResult<List<GetEmpresa>>> GetEmpresas()
        {
            var response = await mediator.Send(new GetEmpresaQuery { });
            return Ok(response);
        }
    }
}
