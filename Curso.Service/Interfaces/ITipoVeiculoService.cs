using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.DTO;

namespace Curso.Service.Interfaces
{
    public interface ITipoVeiculoService
    {
        List<TipoVeiculoDTO> List();
        TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDB);
        bool Delete(long id);
        TipoVeiculoDTO Update(TipoVeiculoDTO tipoVeiculoDB);
        TipoVeiculoDTO Get(long id);
    }
}
