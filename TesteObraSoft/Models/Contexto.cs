using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TesteObraSoft.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
