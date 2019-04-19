namespace PrototipoVendas.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PrototipoVendas.Dominio.Entidades;

    public class BaseController : Controller
    {
        public class BaseUsuarioLogado
        {
            public Usuario Usuario { get; set; }
        }

        public BaseUsuarioLogado UsuarioLogado
        {
            get
            {
                var baseUsuarioLogado = new BaseUsuarioLogado();

                var usuarioLogado = HttpContext.Session.Get<BaseUsuarioLogado>("UsuarioLogado");

                if (usuarioLogado != null && !string.IsNullOrEmpty(usuarioLogado.ToString()))
                {
                    baseUsuarioLogado = usuarioLogado;
                }
                return baseUsuarioLogado;
            }
        }
    }
}