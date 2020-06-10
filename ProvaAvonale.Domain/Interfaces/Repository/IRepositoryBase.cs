using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvonale.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
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
