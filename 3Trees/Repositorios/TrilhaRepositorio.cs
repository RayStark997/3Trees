using ThreeTrees.Data;
using ThreeTrees.Model;
using ThreeTrees.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace ThreeTrees.Repositorios
{
    public class TrilhaRepositorio : ITrilhaRepositorio
    {
        private readonly ThreeTreesDBContext _dbContext;
        public TrilhaRepositorio(ThreeTreesDBContext _3treesDBContext)
        {
            _dbContext = _3treesDBContext;
        }

        public async Task<TrilhaModel> BuscarPorId(int id)
        {
            return await _dbContext.Trilhas.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<TrilhaModel> Adicionar(TrilhaModel trilha)
        {
            await _dbContext.Trilhas.AddAsync(trilha);
            await _dbContext.SaveChangesAsync();

            return trilha;
        }

        public async Task<TrilhaModel> Atualizar(TrilhaModel trilha, int id)
        {
            TrilhaModel trilhaPorId = await BuscarPorId(id);

            if (trilhaPorId == null) 
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado no banco de dados.");
            }

            trilhaPorId.Nome = trilha.Nome;
            trilhaPorId.Coordenada = trilha.Coordenada;
            trilhaPorId.Descricao = trilha.Descricao;
            trilhaPorId.Cidade = trilha.Cidade; 
            trilhaPorId.CaminhoImagem = trilha.CaminhoImagem;

            _dbContext.Trilhas.Update(trilhaPorId);
            await _dbContext.SaveChangesAsync();
            
            return trilhaPorId;

        }

        public async Task<bool> Apagar(int id)
        {
            TrilhaModel trilhaPorId = await BuscarPorId(id);

            if (trilhaPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado no banco de dados.");
            }

            _dbContext.Trilhas.Remove(trilhaPorId); 
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TrilhaModel>> BusacarTodasTrilhas()
        {
           return await _dbContext.Trilhas.ToListAsync();
        }
    }
}
