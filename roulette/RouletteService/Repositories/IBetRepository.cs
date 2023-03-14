using System.Threading.Tasks;
using RouletteService.Repositories.Data;

namespace RouletteService.Repositories
{
    public interface IBetRepository
    {
        Task<int> Insert(Bet bet);

    }
}