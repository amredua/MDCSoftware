using MDCSoftware.Dominio.Repositorio;
using MDCSoftware.Negocio.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Infraestrutura.Repositorio
{
    public class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected ContextoInfraestrutura contexto;

        public RepositorioBase(ContextoInfraestrutura contexto)
        {
            this.contexto = contexto;
        }
        public void Adicionar(TEntidade entidade)
        {
            contexto.Set<TEntidade>().Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            contexto.Entry(entidade).State = EntityState.Modified;
        }

        public async Task<TEntidade> ObterPorId(int id)
        {
            return await contexto.Set<TEntidade>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntidade>> ObterTodos()
        {
            return await contexto.Set<TEntidade>().ToListAsync();
        }

        public void Remover(TEntidade entidade)
        {
            contexto.Remove(entidade);
        }
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
