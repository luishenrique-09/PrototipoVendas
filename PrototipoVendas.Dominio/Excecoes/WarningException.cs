namespace PrototipoVendas.Dominio.Excecoes
{
    using System;

    public class WarningException : Exception
    {
        public WarningException()
        {
        }

        public WarningException(string mensagem)
            : base (mensagem)
        {
        }

        public WarningException(string mensagem, Exception innerException)
            : base (mensagem, innerException)
        {
        }

    }
}
