using MDCSoftware.Dominio.Cartao;
using MDCSoftware.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Infraestrutura.Repositorio
{
    public class RepositorioPessoa : RepositorioBase<Pessoa>, IRepositorioPessoa
    {
        public RepositorioPessoa(DbContext context)
         : base(context)
        {

        }
    }
}
