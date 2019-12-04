using MDCSoftware.Negocio.Dominio;
using MDCSoftware.Negocio.Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Negocio.Infraestrutura.Contexto
{
    public class InfraestruturaContext : DbContext
    {
        public InfraestruturaContext(DbContextOptions<InfraestruturaContext> options)
          : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ConfiguracaoPessoa(modelBuilder.Entity<Pessoa>());

        }

    }
}
