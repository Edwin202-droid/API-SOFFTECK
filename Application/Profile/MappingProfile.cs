using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Empresa.Query.GetEmpresaPaginado;
using AutoMapper;
using Domain.Entities;

namespace Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaPaginado>().ReverseMap();
        }
    }
}
