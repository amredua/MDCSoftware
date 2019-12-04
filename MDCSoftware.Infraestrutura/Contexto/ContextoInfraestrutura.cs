using MDCSoftware.Dominio.Cartao;
using MDCSoftware.Infraestrutura.ConfiguracaoMapeamento;
using Microsoft.EntityFrameworkCore;

namespace MDCSoftware.Negocio.Infraestrutura.Contexto
{
    public class ContextoInfraestrutura : DbContext
    {
        public ContextoInfraestrutura(DbContextOptions<ContextoInfraestrutura> options)
          : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ConfiguracaoMapeamentoPessoa(modelBuilder.Entity<Pessoa>());

        }
    }
}
