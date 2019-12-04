using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Aplicacao.Aplicacao
{
    public class AplicacaoBase<TEntidade> : IDisposable, IAplicacaoBase<TEntidade> where TEntidade : class
    {
        private readonly IServicoBase<TEntidade> servico;

        public AplicacaoBase(IServicoBase<TEntidade> servico)
        {
            this.servico = servico;
        }
        public void Adicionar(TEntidade entidade)
        {
            this.servico.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            this.servico.Atualizar(entidade);
        }

        public async Task<TEntidade> ObterPorId(int id)
        {
            return  await this.servico.ObterPorId(id);
        }

        public async Task<IEnumerable<TEntidade>> ObterTodos()
        {
            return await this.servico.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            this.servico.Remover(entidade);
        }
        public void Dispose()
        {
            this.servico.Dispose();
        }
    }
}
