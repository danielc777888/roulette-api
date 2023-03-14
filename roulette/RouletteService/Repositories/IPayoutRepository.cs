using System.Threading.Tasks;
using RouletteService.Repositories.Data;

namespace RouletteService.Repositories
{
    public interface IPayoutRepository
    {
        Task<int> Insert(Payout payout);

    }
}