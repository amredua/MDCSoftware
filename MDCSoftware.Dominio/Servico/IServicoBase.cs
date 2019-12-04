using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Dominio.Servico
{
    public interface IServicoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);
        Task<TEntidade> ObterPorId(int id);
        Task<IEnumerable<TEntidade>> ObterTodos();
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
        void Dispose();
    }
}
