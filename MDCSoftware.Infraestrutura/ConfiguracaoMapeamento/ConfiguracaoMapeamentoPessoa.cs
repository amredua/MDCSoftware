using MDCSoftware.Dominio.Cartao;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Infraestrutura.ConfiguracaoMapeamento
{
    public class ConfiguracaoMapeamentoPessoa
    {
        public ConfiguracaoMapeamentoPessoa(EntityTypeBuilder<Pessoa> pessoa)
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
