using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Aplicacao.Cartao;
using MDCSoftware.Aplicacao.ServicoAplicacao.Interface;
using MDCSoftware.Dominio.Cartao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Aplicacao.ServicoAplicacao
{
    public class ServicoAplicacaoBase<TEntidade> : IDisposable, IServicoAplicacaoBase<TEntidade> where TEntidade : class
    {
        private readonly IAplicacaoBase<TEntidade> aplicacao;

        public ServicoAplicacaoBase(IAplicacaoBase<TEntidade> aplicacao)
        {
            this.aplicacao = aplicacao;
        }

  

    }
}
