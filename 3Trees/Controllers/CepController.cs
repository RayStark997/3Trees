using _3Trees.Integracao.Interfaces;
using _3Trees.Integracao.Response;
using Microsoft.AspNetCore.Mvc;

namespace _3Trees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return BadRequest("Informe um CEP válido.");

            var dados = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if (dados == null)
                return NotFound("CEP não encontrado.");

            return Ok(dados);
        }
    }
}
