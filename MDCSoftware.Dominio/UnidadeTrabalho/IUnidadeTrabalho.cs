using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDCSoftware.Dominio.UnidadeTrabalho
{
    public interface IUnidadeTrabalho : IDisposable
    {
        Task<bool> Commit();
    }
}
