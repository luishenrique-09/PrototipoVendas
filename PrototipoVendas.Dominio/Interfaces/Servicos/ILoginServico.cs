namespace PrototipoVendas.Dominio.Interfaces.Servicos
{
    using Enums;
    using PrototipoVendas.Dominio.Entidades;
    using System;

    public interface ILoginServico
    {
        Tuple<TipoMensagem, string> Autenticar(string login, string senha, int coligada, out Usuario usuarioLogado);
    }
}
