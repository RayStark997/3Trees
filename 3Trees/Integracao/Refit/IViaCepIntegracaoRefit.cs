using _3Trees.Integracao.Response;
using Refit;

namespace _3Trees.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep); 
    }
}
