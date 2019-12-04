using MDCSoftware.Dominio.Cartao;
using MDCSoftware.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDCSoftware.Dominio.Servico
{
    public class ServicoPessoa : ServicoBase<Pessoa>, IServicoPessoa
    {
        private readonly IRepositorioPessoa repositorio;

        public ServicoPessoa(IRepositorioPessoa repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
