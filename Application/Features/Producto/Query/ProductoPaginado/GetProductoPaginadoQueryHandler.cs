using AutoMapper;
using Data.Repositories_Interfaces;
using Helpers.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Producto.Query.ProductoPaginado
{
    public class GetProductoPaginadoQueryHandler : IRequestHandler<GetProductoPaginadoQuery, ResultProductoPaginado>
    {
        private readonly IProductoRepository productoRepository;
        private readonly IMapper mapper;

        public GetProductoPaginadoQueryHandler(IProductoRepository productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }
        public async Task<ResultProductoPaginado> Handle(GetProductoPaginadoQuery request, CancellationToken cancellationToken)
        {
            var result = new ResultProductoPaginado();
            result.records = new List<ProductoPaginadoVm>();

            var productos = productoRepository.ListProductoPaginado(request.Page);

            result.records = mapper.Map<List<ProductoPaginadoVm>>(productos);
            result.paging = new PaginationMetadata
            {
                TotalCount = productos.TotalCount,
                PageSize = productos.PageSize,
                CurrentPage = productos.CurrentPage,
                TotalPages = productos.TotalPages,
            };

            return await Task.Run(() => result);
        }
    }
}
