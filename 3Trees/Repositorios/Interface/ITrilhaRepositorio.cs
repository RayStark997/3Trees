using ThreeTrees.Model;

namespace ThreeTrees.Repositorios.Interface
{
    public interface ITrilhaRepositorio
    {
        Task<List<TrilhaModel>> BusacarTodasTrilhas();
        Task<TrilhaModel> BuscarPorId(int id);
        Task<TrilhaModel> Adicionar(TrilhaModel trilhaModel);
        Task<TrilhaModel> Atualizar(TrilhaModel trilhaModel, int id);
        Task<bool> Apagar(int id);
    }
}
