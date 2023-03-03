using Application.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentantePaginado
{
    public class GetRepresentantePaginadoQuery : BaseRequest, IRequest<ResultRepresentantePaginado>
    {
    }
}
