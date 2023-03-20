using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.DTO;
using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using Curso.Repository.Repository;
using Curso.Service.Interfaces;

namespace Curso.Service.Services
{
    public class VeiculoService : ServiceBase, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public VeiculoDTO Get(long id)
        {
            throw new NotImplementedException();
        }

        public VeiculoDTO Insert(VeiculoDTO veiculoDB)
        {
            Veiculo veiculo = mapper.Map<Veiculo>(veiculoDB);
            veiculo = _veiculoRepository.Insert(veiculo);
            return mapper.Map<VeiculoDTO>(veiculo);
        }

        public List<VeiculoDTO> List()
        {
            List<Veiculo> listVeiculos = _veiculoRepository.List();
            return mapper.Map<List<VeiculoDTO>>(listVeiculos);
        }

        public VeiculoDTO Update(VeiculoDTO veiculoDB)
        {
            throw new NotImplementedException();
        }
    }
}
