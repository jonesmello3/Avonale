using ProvaAvonale.DataAccess.Context;
using ProvaAvonale.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProvaAvonale.DataAccess.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        #region Variáveis
        protected ContextoGitHub contexto = new ContextoGitHub();
        #endregion

        public RepositoryBase()
        {
            contexto.Configuration.LazyLoadingEnabled = false;
            contexto.Configuration.ProxyCreationEnabled = false;
        }

        #region Insert
        public TEntity Inserir(TEntity entity)
        {
            contexto.Set<TEntity>().Add(entity);
            Save();

            return entity;
        }
        #endregion

        #region GetAll
        public IEnumerable<TEntity> ObterTodos()
        {
            var entities = (from entity in contexto.Set<TEntity>()
                            .OrderBy(entity => true)
                            select entity).ToList();

            return entities;
        }
        #endregion

        #region GetById
        public TEntity ObterPorId(Guid id)
        {
            var entity = contexto.Set<TEntity>().Find(id);

            return entity;
        }

        public TEntity ObterPorId(int id)
        {
            var entity = contexto.Set<TEntity>().Find(id);

            return entity;
        }
        #endregion

        #region Edit
        public TEntity Editar(TEntity entity)
        {
            var entry = contexto.Entry(entity);
            contexto.Entry(entity).State = EntityState.Modified;
            Save();

            return entity;
        }
        #endregion

        #region Save
        public void Save()
        {
            contexto.SaveChanges();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            contexto.Dispose();
        }
        #endregion
    }
}
