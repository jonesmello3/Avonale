using System;
using System.Collections.Generic;

namespace ProvaAvonale.ApplicationService.Interfaces
{
    public interface IApplicationServiceBase<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entity);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(Guid id);
        TEntity ObterPorId(int id);
        TEntity Editar(TEntity entity);
        void Save();
        void Dispose();
    }
}
