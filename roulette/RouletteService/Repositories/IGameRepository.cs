using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Repositories.Data;

namespace RouletteService.Repositories
{
    public interface IGameRepository
    {
        Task<int> Insert(Game game);

        Task<Option<Game>> Get(int id);
    }
}