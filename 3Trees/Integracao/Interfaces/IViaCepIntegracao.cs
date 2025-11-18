using _3Trees.Integracao.Response;

namespace _3Trees.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(String cep);
    }
}
