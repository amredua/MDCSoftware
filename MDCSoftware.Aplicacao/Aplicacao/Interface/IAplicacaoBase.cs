using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Aplicacao.Aplicacao.Interface
{
    public interface IAplicacaoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);
        Task<TEntidade> ObterPorId(int id);
        Task<IEnumerable<TEntidade>> ObterTodos();
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
        void Dispose();
    }
}
