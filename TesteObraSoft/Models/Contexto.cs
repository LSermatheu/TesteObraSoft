using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TesteObraSoft.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();   
        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
