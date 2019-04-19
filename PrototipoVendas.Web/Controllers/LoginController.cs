namespace PrototipoVendas.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Infra.Data.Contexto;

    public class LoginController : BaseController
    {
        private readonly VendasContexto _context;

        public LoginController(VendasContexto context)
        {
            _context = context;
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email,Senha")] Usuario usuario)
        {
            var usuarioBD = _context.Usuarios.FirstOrDefault(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha));
            if (usuarioBD != null)
            {
                CriaSessoesUsuario(usuarioBD);
                return RedirectToAction("Index", "Loja");
            }
            else
                ModelState.AddModelError("", "Login ou Senha incorreto.");
            
            return View(usuario);
        }

        private void CriaSessoesUsuario(Usuario usuario)
        {
            BaseUsuarioLogado usuarioLogado = new BaseUsuarioLogado()
            {
                Usuario = usuario
            };

            HttpContext.Session.Set<BaseUsuarioLogado>("UsuarioLogado", usuarioLogado);
            var claims = new[] { new Claim(ClaimTypes.Name, usuario.Email) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                    new ClaimsPrincipal(identity),
                                    new AuthenticationProperties
                                    {
                                        ExpiresUtc = DateTime.Now.AddMinutes(30)
                                    });
        }
    }
}
