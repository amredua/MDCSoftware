using MDCSoftware.Dominio.UnidadeTrabalho;
using MDCSoftware.Negocio.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Infraestrutura.UnidadeTrabalho
{
    public class UnidadeTrabalho : IUnidadeTrabalho
    {
        private readonly ContextoInfraestrutura contexto;

        public UnidadeTrabalho(ContextoInfraestrutura contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> Commit()
        {
            return await contexto.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
