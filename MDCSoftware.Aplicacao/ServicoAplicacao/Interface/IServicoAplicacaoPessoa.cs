using MDCSoftware.Aplicacao.Aplicacao.Interface;
using MDCSoftware.Aplicacao.Cartao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Aplicacao.ServicoAplicacao.Interface
{
    public interface IServicoAplicacaoPessoa
    {
        void Adicionar(DadosPessoa dados);
        Task<DadosPessoa> ObterPorId(int id);
        Task<IEnumerable<DadosPessoa>> ObterTodos();
        void Atualizar(DadosPessoa entidade);
        void Remover(DadosPessoa entidade);
    }
}
