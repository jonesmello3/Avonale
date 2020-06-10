using ProvaAvonale.Domain.Interfaces.Repository;
using ProvaAvonale.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace ProvaAvonale.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        #region Variáveis
        private readonly IRepositoryBase<TEntity> repositoryBase;
        #endregion

        #region Construtor
        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        #endregion

        #region Inserir
        public TEntity Inserir(TEntity entry)
        {
            return repositoryBase.Inserir(entry);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<TEntity> ObterTodos()
        {
            var entities = repositoryBase.ObterTodos();

            return entities;
        }
        #endregion

        #region ObterPorId
        public TEntity ObterPorId(Guid id)
        {
            var entity = repositoryBase.ObterPorId(id);

            return entity;
        }

        public TEntity ObterPorId(int id)
        {
            var entity = repositoryBase.ObterPorId(id);

            return entity;
        }
        #endregion

        #region Editar
        public TEntity Editar(TEntity entry)
        {
            return repositoryBase.Editar(entry);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            repositoryBase.Dispose();
        }
        #endregion

        #region Save
        public void Save()
        {
            repositoryBase.Save();
        }
        #endregion
    }
}
