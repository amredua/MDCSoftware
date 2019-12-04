using MDCSoftware.Dominio.Repositorio;
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
        protected DbContext Db;

        public RepositorioBase(DbContext Db)
        {
            this.Db = Db;
        }
        public void Adicionar(TEntidade entidade)
        {
            Db.Set<TEntidade>().Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
        }

        public async Task<TEntidade> ObterPorId(int id)
        {
            return await Db.Set<TEntidade>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntidade>> ObterTodos()
        {
            return await Db.Set<TEntidade>().ToListAsync();
        }

        public void Remover(TEntidade entidade)
        {
            Db.Remove(entidade);
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
