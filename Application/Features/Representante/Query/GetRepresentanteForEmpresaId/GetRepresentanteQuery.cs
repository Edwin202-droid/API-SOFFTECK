using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentanteForEmpresaId
{
    public class GetRepresentanteQuery : IRequest<List<RepresentanteVm>>
    {
        public Guid EmpresaId { get; set; }
    }
}
