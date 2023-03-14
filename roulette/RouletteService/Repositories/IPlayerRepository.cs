using System.Threading.Tasks;
using RouletteService.Repositories.Data;

namespace RouletteService.Repositories
{
    public interface IPlayerRepository
    {
        Task<int> Insert(Player player);

    }
}