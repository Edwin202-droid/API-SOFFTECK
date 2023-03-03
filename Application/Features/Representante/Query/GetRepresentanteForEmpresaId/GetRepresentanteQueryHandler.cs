using AutoMapper;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentanteForEmpresaId
{
    public class GetRepresentanteQueryHandler : IRequestHandler<GetRepresentanteQuery, List<RepresentanteVm>>
    {
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public GetRepresentanteQueryHandler(IRepresentanteRepository representanteRepository, IMapper mapper)
        {
            this.representanteRepository = representanteRepository;
            this.mapper = mapper;
        }
        public async Task<List<RepresentanteVm>> Handle(GetRepresentanteQuery request, CancellationToken cancellationToken)
        {
            var representantes = await representanteRepository.GetRepresentantes(request.EmpresaId);
            return mapper.Map<List<RepresentanteVm>>(representantes);
        }
    }
}
