namespace PrototipoVendas.Infra.Data.Repositorios
{
    using Dominio.Entidades;
    using Dominio.Interfaces.Repositorio;
    using Infra.Data.Contexto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity>
        where TEntity : class
    {
        private readonly VendasContexto _context;

        public RepositorioBase(VendasContexto contexto)
        {
            _context = contexto;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _context.Set<TEntity>().Where(predicate).FirstOrDefault();
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();
            return query.Where(predicate);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Count(predicate);
        }
        public virtual int GetCount()
        {
            return _context.Set<TEntity>().Count();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit() => _context.SaveChanges();

    }
}
