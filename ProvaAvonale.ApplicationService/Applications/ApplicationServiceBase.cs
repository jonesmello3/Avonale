using ProvaAvonale.ApplicationService.Interfaces;
using ProvaAvonale.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace ProvaAvonale.ApplicationService.Applications
{
    public class ApplicationServiceBase<TEntity> : IApplicationServiceBase<TEntity> where TEntity : class
    {
        #region Variáveis
        private readonly IServiceBase<TEntity> serviceBase;
        #endregion

        #region Construtor
        public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
        {
            this.serviceBase = serviceBase;
        }
        #endregion

        #region Inserir
        public TEntity Inserir(TEntity entry)
        {
            return serviceBase.Inserir(entry);
        }
        #endregion

        #region ObterTodos
        public IEnumerable<TEntity> ObterTodos()
        {
            var entities = serviceBase.ObterTodos();

            return entities;
        }
        #endregion

        #region ObterPorId
        public TEntity ObterPorId(Guid id)
        {
            var entity = serviceBase.ObterPorId(id);

            return entity;
        }

        public TEntity ObterPorId(int id)
        {
            var entity = serviceBase.ObterPorId(id);

            return entity;
        }
        #endregion

        #region Editar
        public TEntity Editar(TEntity entry)
        {
            return serviceBase.Editar(entry);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            serviceBase.Dispose();
        }
        #endregion

        #region Save
        public void Save()
        {
            serviceBase.Save();
        }
        #endregion
    }
}
