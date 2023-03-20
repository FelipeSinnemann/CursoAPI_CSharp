using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repository.Context
{
    public class CursoDBContext : DbContext
    {
        public CursoDBContext(DbContextOptions<CursoDBContext> options) : base(options) { }

        public DbSet<TipoVeiculo> TipoVeiculo { get;set; }
        public DbSet<Veiculo> Veiculo { get;set;}
    }
}
