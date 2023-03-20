using Curso.Domain.DTO;
using Curso.Domain.Entities;
using Curso.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoVeiculoController : ControllerBase
    {
        private readonly ITipoVeiculoService _tipoVeiculoService;

        public TipoVeiculoController(ITipoVeiculoService tipoService)
        {
            _tipoVeiculoService = tipoService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(long id) 
        {
            var tipoVeiculo = _tipoVeiculoService.Get(id);
            return Ok(tipoVeiculo);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            List<TipoVeiculoDTO> listTipos = _tipoVeiculoService.List();
            return Ok(listTipos);
        }

        [HttpPost]
        [Route("Insert")]

        public IActionResult Insert(TipoVeiculoDTO tipoVeiculo)
        {
            return Ok(_tipoVeiculoService.Insert(tipoVeiculo));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(TipoVeiculoDTO tipoVeiculo)
        {
            return Ok(_tipoVeiculoService.Update(tipoVeiculo));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(long id)
        {
            return Ok(_tipoVeiculoService.Delete(id));
        }
    }
}
