namespace PrototipoVendas.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Infra.Data.Contexto;

    public class LoginController : Controller
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
            if (_context.Usuarios.Any(u => u.Email.Equals(usuario.Email) && u.Senha.Equals(usuario.Senha)))
                RedirectToAction("Index", "Home");
            else
                ModelState.AddModelError("", "Login ou Senha incorreto.");
            
            return View(usuario);
        }
    }
}
