using AutoMapper;
using Data.Repositories_Interfaces;
using Helpers.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentantePaginado
{
    public class GetRepresentantePaginadoQueryHandler : IRequestHandler<GetRepresentantePaginadoQuery, ResultRepresentantePaginado>
    {
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public GetRepresentantePaginadoQueryHandler(IRepresentanteRepository representanteRepository, IMapper mapper)
        {
            this.representanteRepository = representanteRepository;
            this.mapper = mapper;
        }
        public async Task<ResultRepresentantePaginado> Handle(GetRepresentantePaginadoQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultRepresentantePaginado();
            result.records = new List<RepresentantePaginado>();

            var representantes = representanteRepository.ListRepresentantePaginado(request.Page);

            result.records = mapper.Map<List<RepresentantePaginado>>(representantes);
            result.paging = new PaginationMetadata
            {
                TotalCount = representantes.TotalCount,
                PageSize = representantes.PageSize,
                CurrentPage = representantes.CurrentPage,
                TotalPages = representantes.TotalPages,
            };

            return await Task.Run(() => result);
        }
    }
}
