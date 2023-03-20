using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.Entities;

namespace Curso.Repository.Interfaces
{
    public interface IVeiculoRepository
    {
        List<Veiculo> List();
        Veiculo Insert(Veiculo veiculo);
        bool Delete(long id);
        Veiculo Update(Veiculo veiculo);
        Veiculo Get(long id);

    }
}
