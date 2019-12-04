using MDCSoftware.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Dominio.Servico
{
    public class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            this.repositorio = repositorio;
        }
        public void Adicionar(TEntidade entidade)
        {
            this.repositorio.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            this.repositorio.Atualizar(entidade);
        }

        public async Task<TEntidade> ObterPorId(int id)
        {
            return await this.repositorio.ObterPorId(id);
        }

        public async Task<IEnumerable<TEntidade>> ObterTodos()
        {
            return  await this.repositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            this.repositorio.Remover(entidade);
        }
        public void Dispose()
        {
            this.repositorio.Dispose();
        }
    }
}
