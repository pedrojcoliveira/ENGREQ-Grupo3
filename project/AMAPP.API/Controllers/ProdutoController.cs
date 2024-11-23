using AMAPP.API.DTOs.Produto;
using AMAPP.API.Models;
using AMAPP.API.Repository;
using AMAPP.API.Repository.ProdutoRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Produto>))]
        public IActionResult GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Create(ProdutoDto novoProdutoDto)
        {
            Produto newProduto = new Produto
            {
                Nome = novoProdutoDto.Nome,
                DescricaoBreve = novoProdutoDto.DescricaoBreve,
                Fotografia = novoProdutoDto.Fotografia,
                PrecoReferencia = novoProdutoDto.PrecoReferencia,
                UnidadesEntrega = novoProdutoDto.UnidadesEntrega,
                TipoProdutoId = novoProdutoDto.TipoProdutoId
            };

            _produtoRepository.Add(newProduto);

            return Created();
        }

    }
}
