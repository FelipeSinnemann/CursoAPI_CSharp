using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Curso.Service.Services
{
    public class ServiceBase
    {
        protected readonly IMapper mapper;
        public ServiceBase()
        {
            mapper = Mappers.MapperDTO.InitializeMapping();
        }
    }
}
