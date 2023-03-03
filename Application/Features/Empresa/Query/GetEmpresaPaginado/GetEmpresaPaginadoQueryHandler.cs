using AutoMapper;
using Data.Repositories_Interfaces;
using Helpers.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empresa.Query.GetEmpresaPaginado
{
    public class GetEmpresaPaginadoQueryHandler : IRequestHandler<GetEmpresaPaginadoQuery, ResultEmpresaPaginado>
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IMapper mapper;

        public GetEmpresaPaginadoQueryHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
        }
        public async Task<ResultEmpresaPaginado> Handle(GetEmpresaPaginadoQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultEmpresaPaginado();
            result.records = new List<EmpresaPaginado>();

            var empresas = empresaRepository.ListEmpresaPaginado(request.Page);

            result.records = mapper.Map<List<EmpresaPaginado>>(empresas);
            result.paging = new PaginationMetadata
            {
                TotalCount = empresas.TotalCount,
                PageSize = empresas.PageSize,
                CurrentPage = empresas.CurrentPage,
                TotalPages = empresas.TotalPages,
            };

            return await Task.Run(() => result);
        }
    }
}
