using MDCSoftware.Dominio.Cartao;
using MDCSoftware.Dominio.Servico;

namespace MDCSoftware.Aplicacao.Aplicacao
{
    public class AplicacaoPessoa : AplicacaoBase<Pessoa>, Interface.IAplicacaoPessoa
    {
        private readonly IServicoPessoa servico;

        public AplicacaoPessoa(IServicoPessoa servico)
            : base(servico)
        {
            this.servico = servico;
        }
    }
}
