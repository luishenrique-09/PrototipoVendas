namespace PrototipoVendas.Dominio.Interfaces.Servicos
{
    using Dominio.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IServicoBase<TEntity>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Commit();

    }
}
