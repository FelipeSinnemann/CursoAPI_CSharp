using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.Entities;

namespace Curso.Repository.Interfaces
{
    public interface ITipoVeiculoRepository
    {
        List<TipoVeiculo> List();
        TipoVeiculo Insert(TipoVeiculo tipoVeiculo);
        bool Delete(long id);
        TipoVeiculo Update(TipoVeiculo tipoVeiculo);
        TipoVeiculo Get(long id);
    }
}
