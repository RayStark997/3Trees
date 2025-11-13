using ThreeTrees.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeTrees.Repositorios.Interface;
using System.IO;

namespace ThreeTrees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrilhaController : ControllerBase
    {
        private readonly ITrilhaRepositorio _trilhaRepositorio;

    public TrilhaController(ITrilhaRepositorio trilhaRepositorio)
        {
            _trilhaRepositorio = trilhaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrilhaModel>>> BuscarTodasTrilhas()
        {
            var trilhas = await _trilhaRepositorio.BusacarTodasTrilhas();
            return Ok(trilhas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrilhaModel>> BuscarPorId(int id)
        {
            var trilha = await _trilhaRepositorio.BuscarPorId(id);
            return Ok(trilha);
        }

        [HttpPost]
        public async Task<ActionResult<TrilhaModel>> Cadastrar([FromForm] TrilhaModel trilhaModel, IFormFile imagem)
        {
            if (imagem != null && imagem.Length > 0)
            {
                var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                var caminho = Path.Combine(pasta, imagem.FileName);
                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                trilhaModel.CaminhoImagem = Path.Combine("imagens", imagem.FileName);
            }

            var trilha = await _trilhaRepositorio.Adicionar(trilhaModel);
            return Ok(trilha);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrilhaModel>> Atualizar([FromForm] TrilhaModel trilhaModel, int id, IFormFile imagem)
        {
            trilhaModel.Id = id;

            if (imagem != null && imagem.Length > 0)
            {
                var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                var caminho = Path.Combine(pasta, imagem.FileName);
                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                }

                trilhaModel.CaminhoImagem = Path.Combine("imagens", imagem.FileName);
            }

            var trilha = await _trilhaRepositorio.Atualizar(trilhaModel, id);
            return Ok(trilha);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            var apagado = await _trilhaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }  

}
