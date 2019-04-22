namespace PrototipoVendas.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Infra.Data.Contexto;
    using PrototipoVendas.Web.Models;

    public class ProdutoController : BaseController
    {
        private readonly VendasContexto _context;

        public ProdutoController(VendasContexto context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            if (UsuarioLogado.Usuario != null)
                return RedirectToAction("Index", "Loja");

            return View(await _context.Produtos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            var retorno = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco.ToString(),
                Foto = ToBase64ImageString(produto.Foto)
            };

            return View(retorno);
        }

        private string ToBase64ImageString(byte[] data)
        {
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto {
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Preco = Convert.ToDecimal(model.Preco)
                };

                MemoryStream ms = new MemoryStream();
                model.ImageUpload.OpenReadStream().CopyTo(ms);

                produto.Foto = ms.ToArray();

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var retorno = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco.ToString(),
                Foto = ToBase64ImageString(produto.Foto)
            };

            return View(retorno);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco")] ProdutoViewModel model
            )
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produto = _context.Produtos.FirstOrDefault(x => x.Id == model.Id);
                    produto.Nome = model.Nome;
                    produto.Descricao = model.Descricao;
                    produto.Preco = Convert.ToDecimal(model.Preco);

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            var retorno = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco.ToString(),
                Foto = ToBase64ImageString(produto.Foto)
            };

            return View(retorno);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
