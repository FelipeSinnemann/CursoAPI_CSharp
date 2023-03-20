using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.DTO
{
    public class VeiculoDTO
    {
        public long id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string placa { get; set; }
        public string cor { get; set; }
        public int ano { get; set; }
        public int tipo { get; set; }

    }
}
