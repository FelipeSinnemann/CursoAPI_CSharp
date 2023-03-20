using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Curso.Domain.DTO;
using Curso.Domain.Entities;

namespace Curso.Service.Mappers
{
    public static class MapperDTO
    {
        public static IMapper InitializeMapping()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoVeiculo, TipoVeiculoDTO>();
                cfg.CreateMap<TipoVeiculoDTO, TipoVeiculo>();

                cfg.CreateMap<Veiculo, VeiculoDTO>();
                cfg.CreateMap<VeiculoDTO, Veiculo>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}
