using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domain.Entities
{
    [Table("tipo_veiculo")]
    public class TipoVeiculo
    {
        [Key]
        public long id { get; set; }
        //[Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string? descricao { get; set; }
    }
}
