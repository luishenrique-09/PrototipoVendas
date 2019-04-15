namespace PrototipoVendas.Dominio.Interfaces.Servicos
{
    using Entidades;
    using System.Collections.Generic;

    public interface IUsuarioServico : IServicoBase<Usuario>
    {
        string ObterFoto(string matricula);
    }
}
