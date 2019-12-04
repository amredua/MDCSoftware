using MDCSoftware.Negocio.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Negocio.Infraestrutura.Configuracao
{
    public class ConfiguracaoPessoa
    {
        public ConfiguracaoPessoa(EntityTypeBuilder<Pessoa> pessoa)
        {
            pessoa.HasKey(w => w.IdPessoa);

            pessoa.Property(w => w.CPF)
              .IsRequired();

            pessoa.Property(w => w.CarteiraIdentidade)
             .IsRequired();

            pessoa.Property(w => w.DataNascimento)
            .IsRequired();

            pessoa.Property(w => w.Foto);
           
        }
    }
}
