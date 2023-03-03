using Application.Request;
using Helpers.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empresa.Query.GetEmpresaPaginado
{
    public class GetEmpresaPaginadoQuery : BaseRequest ,  IRequest<ResultEmpresaPaginado>
    {
    }
}
