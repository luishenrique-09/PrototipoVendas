namespace PrototipoVendas.Infra.Data.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Dominio.Interfaces.Repositorio;
    using PrototipoVendas.Infra.Data.Contexto;

    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        private readonly VendasContexto _contexto;

        public RepositorioUsuario(VendasContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override IEnumerable<Usuario> GetAll()
        {
            var usuarios = _contexto.Usuarios;

            return usuarios;
        }

        public override IQueryable<Usuario> FindBy(Expression<Func<Usuario, bool>> predicate)
        {
            IQueryable<Usuario> query = _contexto.Usuarios
                .AsQueryable();
            return query.Where(predicate);
        }

    }
}
