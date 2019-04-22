namespace PrototipoVendas.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Infra.Data.Contexto;
    using PrototipoVendas.Web.Models;

    [Authorize]
    public class LojaController : Controller
    {
        private readonly VendasContexto _context;

        public LojaController(VendasContexto context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var listaProdutos = new List<ProdutoViewModel>();
            var produtosBD = await _context.Produtos.ToListAsync();
            foreach (var prod in produtosBD)
            {
                listaProdutos.Add(new ProdutoViewModel
                {
                    Id = prod.Id,
                    Nome = prod.Nome,
                    Descricao = prod.Descricao,
                    Preco = prod.Preco.ToString(),
                    Foto = ToBase64ImageString(prod.Foto)
                });
            }

            return View(listaProdutos);
        }

        // GET: Loja/Details/5
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
        
        public IActionResult AdicionarAoCarrinho(int idProduto, int quantidade = 1, string page = "Index")
        {
            var itensCarrinho = HttpContext.Session.Get<List<CarrinhoViewModel>>("Carrinho");

            if (itensCarrinho == null)
                itensCarrinho = new List<CarrinhoViewModel>();

            var produto = ObterProduto(idProduto);
            itensCarrinho.Add(new CarrinhoViewModel { Produto = produto, Quantidade = quantidade });

            HttpContext.Session.Set<List<CarrinhoViewModel>>("Carrinho", itensCarrinho);

            return RedirectToAction(page, new { id = produto.Id });
        }

        private ProdutoViewModel ObterProduto(int idProduto)
        {
            var produtoBD = _context.Produtos.FirstOrDefault(x => x.Id == idProduto);
            var produtoVM = new ProdutoViewModel
            {
                Id = produtoBD.Id,
                Nome = produtoBD.Nome,
                Descricao = produtoBD.Descricao,
                Preco = produtoBD.Preco.ToString(),
                Foto = ToBase64ImageString(produtoBD.Foto)
            };

            return produtoVM;
        }

        private string ToBase64ImageString(byte[] data)
        {
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
        }
        
        public IActionResult Carrinho()
        {
            var itensCarrinho = HttpContext.Session.Get<List<CarrinhoViewModel>>("Carrinho");

            return View(itensCarrinho);
        }
    }
}
